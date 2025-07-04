﻿using LiveCore.Desktop.SBase.MenuManager;
using Sentez.Common;
using Sentez.Common.Commands;
using Sentez.Common.ModuleBase;
using Sentez.Common.ResourceManager;
using Sentez.Common.SystemServices;
using Sentez.Data.MetaData.DatabaseControl;
using System;
using System.IO;
using System.Reflection;
using EgeHayatDoorManagementModule.Services;
using Sentez.Data.MetaData;
using Sentez.Data.Tools;
using Sentez.Localization;
using LiveCore.Desktop.Common;
using Prism.Ioc;
using Sentez.EgeHayatDoorManagementModule.PresentationModels;
using Sentez.Common.SBase;
using Sentez.Data.BusinessObjects;
using EgeHayatDoorManagementModule.Models;
using EgeHayatDoorManagementModule.BoExtensions;

namespace Sentez.EgeHayatDoorManagementModule
{
    public partial class EgeHayatDoorManagementModule : LiveModule
    {
        //Deneme değişiklik
        IContainerExtension _container;
        SysMng _sysMng;
        LiveSession ActiveSession
        {
            get
            {
                return SysMng.Instance.getSession();
            }
        }

        public Stream _MenuDefination = null;
        public override Stream MenuDefination
        {
            get
            {
                return _MenuDefination;
            }
        }

        public override short moduleID { get { return (short)Modules.ExternalModule17; } }

        public EgeHayatDoorManagementModule(IContainerExtension container)
        {
            _container = container;
            _sysMng = _container.Resolve<SysMng>();
            if (_sysMng != null)
            {
                _sysMng.AfterDesktopLogin += _sysMng_AfterDesktopLogin;
            }
        }
        public override void OnRegister(IContainerRegistry containerRegistry)
        {
            RegisterCoreDocuments();
            RegisterBO();
            RegisterViews();
            RegisterRes();
            RegisterRpr();
            RegisterPM();
            RegisterModuleCommands();
            RegisterServices();
            RegisterList();
            EgeHayatDoorManagementModuleSecurity.RegisterSecurityDefinitions();

            MenuManager.Instance.RegisterMenu("EgeHayatDoorManagementModule", "EgeHayatDoorManagementModuleMenu", moduleID, true);
        }

        public override void OnInitialize(IContainerProvider containerProvider)
        {
            _sysMng.AddApplication("EgeHayatDoorManagementModule");
        }

        public override void RegisterModuleCommands()
        {
        }


        private void _sysMng_AfterDesktopLogin(object sender, EventArgs e)
        {
            //if (!Schema.Tables["Erp_DemandReceiptItem"].Fields.Contains("UD_SizeDetailCode"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_DemandReceiptItem", "UD_SizeDetailCode", SLanguage.GetString("Ölçü Kodu"), (byte)UdtType.UdtCode, (byte)FieldUsage.Code, (byte)EditorType.ListSelector, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_OrderReceiptItem"].Fields.Contains("UD_SizeDetailCode"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_OrderReceiptItem", "UD_SizeDetailCode", SLanguage.GetString("Ölçü Kodu"), (byte)UdtType.UdtCode, (byte)FieldUsage.Code, (byte)EditorType.ListSelector, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_InventoryPriceList"].Fields.Contains("UD_Variant1PriceEfective"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_InventoryPriceList", "UD_Variant1PriceEfective", SLanguage.GetString("Varyant-1 Fiyatta Etkili"), (byte)UdtType.UdtBool, (byte)FieldUsage.Bool, (byte)EditorType.CheckBox, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_InventoryPriceList"].Fields.Contains("UD_Variant2PriceEfective"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_InventoryPriceList", "UD_Variant2PriceEfective", SLanguage.GetString("Varyant-2 Fiyatta Etkili"), (byte)UdtType.UdtBool, (byte)FieldUsage.Bool, (byte)EditorType.CheckBox, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_InventoryPriceList"].Fields.Contains("UD_Variant3PriceEfective"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_InventoryPriceList", "UD_Variant3PriceEfective", SLanguage.GetString("Varyant-3 Fiyatta Etkili"), (byte)UdtType.UdtBool, (byte)FieldUsage.Bool, (byte)EditorType.CheckBox, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_InventoryPriceList"].Fields.Contains("UD_Variant4PriceEfective"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_InventoryPriceList", "UD_Variant4PriceEfective", SLanguage.GetString("Varyant-4 Fiyatta Etkili"), (byte)UdtType.UdtBool, (byte)FieldUsage.Bool, (byte)EditorType.CheckBox, (byte)ValueInputMethod.FreeType, 0);
            //if (!Schema.Tables["Erp_InventoryPriceList"].Fields.Contains("UD_Variant5PriceEfective"))
            //    CreatMetaDataFieldsService.CreatMetaDataFields("Erp_InventoryPriceList", "UD_Variant5PriceEfective", SLanguage.GetString("Varyant-5 Fiyatta Etkili"), (byte)UdtType.UdtBool, (byte)FieldUsage.Bool, (byte)EditorType.CheckBox, (byte)ValueInputMethod.FreeType, 0);
        }

        public void Initialize()
        {
        }

        private void RegisterBO()
        {
            _container.Register<IBusinessObject, ReservationPosBO>("ReservationPosBO");
        }

        private void RegisterServices()
        {
            _container.Register<ISystemService, CreatMetaDataFieldsService>("CreatMetaDataFieldsService");
            BusinessObjectBase.AddCustomExtension("OrderReceiptBO", typeof(OrderReceiptControlExtension));
        }

        private void RegisterRes()
        {
            ResMng.AddRes("EgeHayatDoorManagementModuleMenu", "EgeHayatDoorManagementModule;component/ModuleMenu.xml", ResSource.Resource, ResourceType.MenuXml, Modules.ExternalModule15, 0, 0);
        }

        private void RegisterList()
        {
            //_container.Register<IReport, UnitItemSizeSetDetailsList>("Erp_UnitItemSizeSetDetailsSizeDetailCodeList");
        }

        private void RegisterViews()
        {
            //ResMng.AddRes("SalesShipmentCompare", "EgeHayatDoorManagementModule;component/Views/SalesShipmentCompare.xaml", ResSource.Resource, ResourceType.View, Modules.ExternalModule15, 0, 0);
            ResMng.AddRes("PosReservationListDetailsView", "EgeHayatDoorManagementModule;component/Views/PosReservationListDetails.xaml", ResSource.Resource, ResourceType.View, Modules.ExternalModule15, 0, 0);
        }

        private void RegisterPM()
        {
            _container.Register<IPMBase, PosReservationListDetailsPM>("PosReservationListDetailsPM");
        }

        private void RegisterRpr()
        {
            //_container.Register<IReport, SalesShipmentComparePolicy>("SalesShipmentComparePolicy");
        }

        public void RegisterCoreDocuments()
        {
            Data.MetaData.Schema.ReadXml(Assembly.GetAssembly(typeof(EgeHayatDoorManagementModule)).GetManifestResourceStream("EgeHayatDoorManagementModule.EgeHayatDoorManagementModuleDataSchema.xml"));
            DbCreator.AddRegistration(3014, EgeHayatDoorManagementModuleDbUpdateScript);
        }

        DbScripts EgeHayatDoorManagementModuleDbUpdateScript(DbCreator instance)
        {
            return DbScripts.LoadFromAssembly(Assembly.GetAssembly(typeof(EgeHayatDoorManagementModule)), "EgeHayatDoorManagementModule.EgeHayatDoorManagementModuleDbUpdateScripts.xml");
        }
    }
}
