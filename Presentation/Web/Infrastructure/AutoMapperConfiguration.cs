﻿using AutoMapper;
using Core.Domain;
using Core.Domain.Common;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;

        private static IMapper _mapper;

        public static void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, Core.Domain.Common.Users>();
                cfg.CreateMap<Core.Domain.Common.Users, UserModel>();
                cfg.CreateMap<GoodsDataModel, GoodsData>();
                cfg.CreateMap<GoodsData, GoodsDataModel>();
                cfg.CreateMap<ClientDataModel, ClientData>();
                cfg.CreateMap<ClientData, ClientDataModel>();
                cfg.CreateMap<SupplierDataModel, SupplierData>();
                cfg.CreateMap<SupplierData, SupplierDataModel>();
                cfg.CreateMap<PurchaseDataModel, PurchaseData>();
                cfg.CreateMap<PurchaseData, PurchaseDataModel>();
                cfg.CreateMap<SalesShipmentsDataModel, SalesShipmentsData>();
                cfg.CreateMap<SalesShipmentsData, SalesShipmentsDataModel>();
                cfg.CreateMap<InventoryDataModel, InventoryData>();
                cfg.CreateMap<InventoryData, InventoryDataModel>();
                cfg.CreateMap<WarehouseModel, Warehouse>();
                cfg.CreateMap<Warehouse, WarehouseModel>();
                cfg.CreateMap<GoodsSpecificationModel, GoodsSpecification>();
                cfg.CreateMap<GoodsSpecification, GoodsSpecificationModel>();
                cfg.CreateMap<GoodsTypeModel, GoodsType>();
                cfg.CreateMap<GoodsType, GoodsTypeModel>();
                cfg.CreateMap<ClientTypeModel, ClientType>();
                cfg.CreateMap<ClientType, ClientTypeModel>();
                cfg.CreateMap<SupplierTypeModel, SupplierType>();
                cfg.CreateMap<SupplierType, SupplierTypeModel>();
                cfg.CreateMap<GoodsUnitModel, GoodsUnit>();
                cfg.CreateMap<GoodsUnit, GoodsUnitModel>();
                cfg.CreateMap<TransferCargoDataModel, TransferCargoData>();
                cfg.CreateMap<TransferCargoData, TransferCargoDataModel>();

                cfg.CreateMap<ArrearsDataModel, ArrearsData>();
                cfg.CreateMap<ArrearsData, ArrearsDataModel>();
                cfg.CreateMap<ArrearsDetailsModel, ArrearsDetails>();
                cfg.CreateMap<ArrearsDetails, ArrearsDetailsModel>();

                cfg.CreateMap<SalesShipmentsStatisticsModel, SalesShipmentsStatisticsModelShow>();
                cfg.CreateMap<SalesShipmentsStatisticsModelShow, SalesShipmentsStatisticsModel>();
                cfg.CreateMap<ArrearsStatisticsModel, ArrearsStatisticsShow>();
                cfg.CreateMap<ArrearsStatisticsShow, ArrearsStatisticsModel>();
                
            });

            _mapper = _mapperConfiguration.CreateMapper();

        }

        public static IMapper Mapper => _mapper;

        public static MapperConfiguration MapperConfiguration => _mapperConfiguration;
    }
}