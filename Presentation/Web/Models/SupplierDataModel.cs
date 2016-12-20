﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SupplierDataModel
    {
        public int ID { get; set; }

        [DisplayName("供应商名称")]
        public string SupplierName { get; set; }

        [DisplayName("公司名称")]
        public string CompanyName { get; set; }

        [DisplayName("联系人")]
        public string Contacts { get; set; }

        [DisplayName("供应商类别")]
        public string SupplierType { get; set; }

        [DisplayName("区域")]
        public string Area { get; set; }

        [DisplayName("地址")]
        public string Address { get; set; }

        [DisplayName("手机")]
        public string Phone { get; set; }

        [DisplayName("座机")]
        public string Telephone { get; set; }

        [DisplayName("欠款")]
        public string Arrears { get; set; }

        [DisplayName("还款日期")]
        public DateTime RepaymentDate { get; set; }

        [DisplayName("开户行")]
        public string Banks { get; set; }

        [DisplayName("开户名")]
        public string AccountName { get; set; }

        [DisplayName("银行账号")]
        public string BankAccount { get; set; }

        [DisplayName("税号")]
        public string TaxIdentificationNumber { get; set; }

        [DisplayName("排序号")]
        public string Seq { get; set; }

        [DisplayName("备注1")]
        public string Remarks1 { get; set; }

        [DisplayName("备注2")]
        public string Remarks2 { get; set; }

        [DisplayName("备注3")]
        public string Remarks3 { get; set; }

        [DisplayName("备注4")]
        public string Remarks4 { get; set; }
    }
}