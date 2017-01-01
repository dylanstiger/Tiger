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
    public class SalesShipmentsDataService
    {
        private readonly DapperRepository _repository;
        private readonly IDbConnection _context;

        public SalesShipmentsDataService(DapperRepository repository,
            IDbConnection context)
        {
            _repository = repository;
            _context = context;
        }

        public void Insert(SalesShipmentsData SalesShipmentsData)
        {
            var sql = $@"insert into SalesShipmentsData(
                    Goods_ID,
                    Goods_Name,
                    Date,
                    Unit,
                    Specification,
                    GoodsType,
                    Brand,
                    Quantity,
                    UnitPrice,
                    Cost,
                    Profit,
                    Sum,
                    Total,
                    Remarks,
                    Supplier_ID,
                    Supplier_Name,
                    Supplier_Address)
			        VALUES (
                    @GoodsID,
                    @GoodsName,
                    @Date,
                    @Unit,
                    @Specification,
                    @GoodsType,
                    @Brand,
                    @Quantity,
                    @UnitPrice,
                    @Cost,
                    @Profit,
                    @Sum,
                    @Total,
                    @Remarks,
                    @SupplierID,
                    @SupplierName,
                    @SupplierAddress)";
            _context.Execute(sql, new
            {
                GoodsID = SalesShipmentsData.GoodsID,
                GoodsName = SalesShipmentsData.GoodsName,
                Unit = SalesShipmentsData.Unit,
                Specification = SalesShipmentsData.Specification,
                GoodsType = SalesShipmentsData.GoodsType,
                Brand = SalesShipmentsData.Brand,
                Quantity = SalesShipmentsData.Quantity,
                UnitPrice = SalesShipmentsData.UnitPrice,
                Cost = SalesShipmentsData.Cost,
                Profit = SalesShipmentsData.Profit,
                Sum = SalesShipmentsData.Sum,
                Total = SalesShipmentsData.Total,
                Remarks = SalesShipmentsData.Remarks,
                SupplierID = SalesShipmentsData.SupplierID,
                SupplierName = SalesShipmentsData.SupplierName,
                SupplierAddress = SalesShipmentsData.SupplierAddress
            });
        }

        public void Update(SalesShipmentsData SalesShipmentsData)
        {
            var sql = $@"update SalesShipmentsData set
                    Goods_ID=@GoodsID,
                    Goods_Name=@GoodsName,
                    Date=@Date,
                    Unit=@Unit,
                    Specification=@Specification,
                    GoodsType=@GoodsType,
                    Brand=@Brand,
                    Quantity=@Quantity,
                    UnitPrice=@UnitPrice,
                    Cost=@Cost,
                    Profit=@Profit,
                    Sum=@Sum,
                    Total=@Total,
                    Remarks=@Remarks,
                    Supplier_ID=@SupplierID,
                    Supplier_Name=@SupplierName,
                    Supplier_Address=@SupplierAddress,
                    Remarks2=@Remarks2,
                    Remarks3=@Remarks3,
                    Remarks4=@Remarks4)
                    where ID=@ID";
            _context.Execute(sql, new
            {
                GoodsID = SalesShipmentsData.GoodsID,
                GoodsName = SalesShipmentsData.GoodsName,
                Unit = SalesShipmentsData.Unit,
                Specification = SalesShipmentsData.Specification,
                GoodsType = SalesShipmentsData.GoodsType,
                Brand = SalesShipmentsData.Brand,
                Quantity = SalesShipmentsData.Quantity,
                UnitPrice = SalesShipmentsData.UnitPrice,
                Cost = SalesShipmentsData.Cost,
                Profit = SalesShipmentsData.Profit,
                Sum = SalesShipmentsData.Sum,
                Total = SalesShipmentsData.Total,
                Remarks = SalesShipmentsData.Remarks,
                SupplierID = SalesShipmentsData.SupplierID,
                SupplierName = SalesShipmentsData.SupplierName,
                SupplierAddress = SalesShipmentsData.SupplierAddress
            });

        }

        public SalesShipmentsData GetById(int id)
        {
            var sql = @"select * from SalesShipmentsData  where id = @id";
            return _context.QuerySingle<SalesShipmentsData>(sql, new
            {
                id = id
            });
        }
        public IPagedList<SalesShipmentsData> GetList(string textQuery, int pageIndex = 0, int pageSize = 2147483647, string sortExpression = "")
        {
            string sql = @"select * from PurchaseData";
            var Parameter = new DynamicParameters();
            //Parameter.Add("textQuery", textQuery);
            return new SqlPagedList<SalesShipmentsData>(sql, Parameter, pageIndex, pageSize, sortExpression);
        }

    }
}