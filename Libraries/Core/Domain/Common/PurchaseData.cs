﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class PurchaseData
    {
        public int ID { get; set; }

        //商品编号
        public int GoodsID { get; set; }

        //商品名称
        public string GoodsName { get; set; }
        //日期
        public DateTime Date { get; set; }

        //单位
        public string Unit { get; set; }

        //规格
        public string Specification { get; set; }

        //商品类别
        public string GoodsType { get; set; }

        //品牌
        public string Brand { get; set; }

        //数量
        public int Quantity { get; set; }

        //单价
        public decimal UnitPrice { get; set; }

        //金额
        public decimal Sum { get; set; }

        //总量
        public string Total { get; set; }

        //备注
        public string Remarks { get; set; }

        //供应商编号
        public int SupplierID { get; set; }

        //供应商名称
        public string SupplierName { get; set; }

        //供应商地址
        public string SupplierAddress { get; set; }

        public int WarehouseID { get; set; }

        public string WarehouseName { get; set; }

        //库存ID
        public int InventoryDataID { get; set; }

        //有效性
        public string Active { get; set; }

        //运费
        public decimal Freight { get; set; }
    }
}
