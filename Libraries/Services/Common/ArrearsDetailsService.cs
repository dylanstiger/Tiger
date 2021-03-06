﻿using Core.Domain.Common;
using Core.Page;
using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public class ArrearsDetailsService
    {
        private readonly DapperRepository _repository;
        private readonly IDbConnection _context;
        private readonly ArrearsDataService _arrearsDataService;

        public ArrearsDetailsService(DapperRepository repository,
            IDbConnection context,
            ArrearsDataService arrearsDataService)
        {
            _repository = repository;
            _context = context;
            _arrearsDataService = arrearsDataService;
        }

        public void Insert(ArrearsDetails ArrearsDetails)
        {
            var sql = $@"insert into ArrearsDetails(
                    Goods_ID,
                    Goods_Name,
                    Arrears_ID,
                    SalesShipmentsData_ID,
                    Quantity,
                    UnitPrice,
                    ArrearsAmount,
                    Sum)
			        VALUES (
                    @GoodsID,
                    @GoodsName,
                    @ArrearsID,
                    @SalesShipmentsDataID,
                    @Quantity,
                    @UnitPrice,
                    @ArrearsAmount,
                    @Sum)";
            _context.Execute(sql, new
            {
                GoodsID = ArrearsDetails.GoodsID,
                GoodsName = ArrearsDetails.GoodsName,
                ArrearsID = ArrearsDetails.ArrearsID,
                SalesShipmentsDataID = ArrearsDetails.SalesShipmentsDataID,
                Quantity = ArrearsDetails.Quantity,
                UnitPrice = ArrearsDetails.UnitPrice,
                ArrearsAmount = ArrearsDetails.ArrearsAmount,
                Sum = ArrearsDetails.Sum
            });
        }

        public void Update(ArrearsDetails ArrearsDetails)
        {
            var sql = $@"update ArrearsDetails set
                    Goods_ID=@GoodsID,
                    Goods_Name=@GoodsName,
                    Arrears_ID=@ArrearsID,
                    SalesShipmentsData_ID=@SalesShipmentsDataID,
                    Quantity=@Quantity,
                    UnitPrice=@UnitPrice,
                    ArrearsAmount=@ArrearsAmount,
                    Sum=@Sum
                    where ID=@ID";
            _context.Execute(sql, new
            {
                GoodsID = ArrearsDetails.GoodsID,
                GoodsName = ArrearsDetails.GoodsName,
                ArrearsID = ArrearsDetails.ArrearsID,
                SalesShipmentsDataID = ArrearsDetails.SalesShipmentsDataID,
                Quantity = ArrearsDetails.Quantity,
                UnitPrice = ArrearsDetails.UnitPrice,
                ArrearsAmount = ArrearsDetails.ArrearsAmount,
                Sum = ArrearsDetails.Sum
            });
        }

        public void UpdateArrears(int arrearsDetailsId, decimal? arrears,int arrearsID,string remarks)
        {
           
            var sql2 = @"select * from ArrearsData  where id = @id";
            ArrearsData arrearsDataRes = _context.QuerySingle<ArrearsData>(sql2, new
            {
                id = arrearsID
            });
            ArrearsDetails arrearsDetailsIdRes = GetById(arrearsDetailsId);
            decimal? newArrears = arrearsDataRes.ArrearsAmount - (arrearsDetailsIdRes.ArrearsAmount- arrears);
            ArrearsData Arrears = _arrearsDataService.GetById(arrearsID);
            var sql3 = $@"update ArrearsData set
                    ArrearsAmount=@ArrearsAmount,
                    Remarks=@remarks
                    where ID=@ID";
            _context.Execute(sql3, new
            {
                ArrearsAmount = newArrears,
                ID = arrearsID,
                remarks= Arrears.Remarks+remarks
            });



            var sql = $@"update ArrearsDetails set
                    ArrearsAmount=@ArrearsAmount
                    where ID=@ID";
            _context.Execute(sql, new
            {
                ArrearsAmount = arrears,
                ID = arrearsDetailsId
            });
        }

        public ArrearsDetails GetById(int id)
        {
            var sql = @"select * from ArrearsDetails  where id = @id";
            return _context.QuerySingle<ArrearsDetails>(sql, new
            {
                id = id
            });
        }

        public IEnumerable<ArrearsDetails> GetByArrearsId(int arrearsID)
        {
            var sql = @"select * from ArrearsDetails  where Arrears_ID = @ArrearsID";
            return _context.Query<ArrearsDetails>(sql,
                new { ArrearsID = arrearsID }
                );
        }

        public IPagedList<ArrearsDetails> GetList(string textQuery, int pageIndex = 0, int pageSize = 2147483647, string sortExpression = "")
        {
            string sql = @"select * from ArrearsDetails ";
            var Parameter = new DynamicParameters();
            if (!string.IsNullOrEmpty(textQuery))
            {
                sql += " where Goods_Name like @textQuery";
                textQuery = textQuery.Contains("%") ? textQuery : $"%{textQuery}%";
                Parameter.Add("textQuery", textQuery);
            }

            return new SqlPagedList<ArrearsDetails>(sql, Parameter, pageIndex, pageSize, sortExpression);
        }


    }
}
