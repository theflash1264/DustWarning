using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Business.Business_OutboundSettingVMs;
using DustWarning.Model.Business;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Business_OutboundSettingControllerTest
    {
        private Business_OutboundSettingController _controller;
        private string _seed;

        public Business_OutboundSettingControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Business_OutboundSettingController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Business_OutboundSettingListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Business_OutboundSettingVM));

            Business_OutboundSettingVM vm = rv.Model as Business_OutboundSettingVM;
            Business_OutboundSetting v = new Business_OutboundSetting();
			
            v.IsCall = true;
            v.EcName = "4wWu";
            v.ApId = "1Hn6dtoJHyywA";
            v.SecretKey = "puND54oD59";
            v.Sign = "8DgJiUojSpWnHYq";
            v.Username = "jTrp";
            v.ApiKey = "cgE82IQx6OFCe";
            v.EntId = "sgoRDF";
            v.RobotNum = "CIu96YUAhouiLAOzB";
            v.OutCallers = "ycw16PiR";
            v.CreateBy = "75sGVOMn9RVPtxddk";
            v.CreateUser = "oiwbTdXlZw";
            v.SurplusAmount = 75;
            v.UnitPrice = 17;
            v.CallInterval = 28;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_OutboundSetting>().Find(v.ID);
				
                Assert.AreEqual(data.IsCall, true);
                Assert.AreEqual(data.EcName, "4wWu");
                Assert.AreEqual(data.ApId, "1Hn6dtoJHyywA");
                Assert.AreEqual(data.SecretKey, "puND54oD59");
                Assert.AreEqual(data.Sign, "8DgJiUojSpWnHYq");
                Assert.AreEqual(data.Username, "jTrp");
                Assert.AreEqual(data.ApiKey, "cgE82IQx6OFCe");
                Assert.AreEqual(data.EntId, "sgoRDF");
                Assert.AreEqual(data.RobotNum, "CIu96YUAhouiLAOzB");
                Assert.AreEqual(data.OutCallers, "ycw16PiR");
                Assert.AreEqual(data.CreateBy, "75sGVOMn9RVPtxddk");
                Assert.AreEqual(data.CreateUser, "oiwbTdXlZw");
                Assert.AreEqual(data.SurplusAmount, 75);
                Assert.AreEqual(data.UnitPrice, 17);
                Assert.AreEqual(data.CallInterval, 28);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Business_OutboundSetting v = new Business_OutboundSetting();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.IsCall = true;
                v.EcName = "4wWu";
                v.ApId = "1Hn6dtoJHyywA";
                v.SecretKey = "puND54oD59";
                v.Sign = "8DgJiUojSpWnHYq";
                v.Username = "jTrp";
                v.ApiKey = "cgE82IQx6OFCe";
                v.EntId = "sgoRDF";
                v.RobotNum = "CIu96YUAhouiLAOzB";
                v.OutCallers = "ycw16PiR";
                v.CreateBy = "75sGVOMn9RVPtxddk";
                v.CreateUser = "oiwbTdXlZw";
                v.SurplusAmount = 75;
                v.UnitPrice = 17;
                v.CallInterval = 28;
                context.Set<Business_OutboundSetting>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_OutboundSettingVM));

            Business_OutboundSettingVM vm = rv.Model as Business_OutboundSettingVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Business_OutboundSetting();
            v.ID = vm.Entity.ID;
       		
            v.IsCall = false;
            v.EcName = "SR88cC";
            v.ApId = "yZ";
            v.SecretKey = "jHU";
            v.Sign = "4rAqE8LRr9NvZhl65qZ";
            v.Username = "3";
            v.ApiKey = "ZVVD64MEH";
            v.EntId = "tmiRN68ksNyC";
            v.RobotNum = "hgTLKD";
            v.OutCallers = "9xUBBbCVhfSAP6";
            v.CreateBy = "Hs4sEPlO";
            v.CreateUser = "6";
            v.SurplusAmount = 24;
            v.UnitPrice = 78;
            v.CallInterval = 0;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.IsCall", "");
            vm.FC.Add("Entity.EcName", "");
            vm.FC.Add("Entity.ApId", "");
            vm.FC.Add("Entity.SecretKey", "");
            vm.FC.Add("Entity.Sign", "");
            vm.FC.Add("Entity.Username", "");
            vm.FC.Add("Entity.ApiKey", "");
            vm.FC.Add("Entity.EntId", "");
            vm.FC.Add("Entity.RobotNum", "");
            vm.FC.Add("Entity.OutCallers", "");
            vm.FC.Add("Entity.CreateBy", "");
            vm.FC.Add("Entity.CreateUser", "");
            vm.FC.Add("Entity.SurplusAmount", "");
            vm.FC.Add("Entity.UnitPrice", "");
            vm.FC.Add("Entity.CallInterval", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_OutboundSetting>().Find(v.ID);
 				
                Assert.AreEqual(data.IsCall, false);
                Assert.AreEqual(data.EcName, "SR88cC");
                Assert.AreEqual(data.ApId, "yZ");
                Assert.AreEqual(data.SecretKey, "jHU");
                Assert.AreEqual(data.Sign, "4rAqE8LRr9NvZhl65qZ");
                Assert.AreEqual(data.Username, "3");
                Assert.AreEqual(data.ApiKey, "ZVVD64MEH");
                Assert.AreEqual(data.EntId, "tmiRN68ksNyC");
                Assert.AreEqual(data.RobotNum, "hgTLKD");
                Assert.AreEqual(data.OutCallers, "9xUBBbCVhfSAP6");
                Assert.AreEqual(data.CreateBy, "Hs4sEPlO");
                Assert.AreEqual(data.CreateUser, "6");
                Assert.AreEqual(data.SurplusAmount, 24);
                Assert.AreEqual(data.UnitPrice, 78);
                Assert.AreEqual(data.CallInterval, 0);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Business_OutboundSetting v = new Business_OutboundSetting();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.IsCall = true;
                v.EcName = "4wWu";
                v.ApId = "1Hn6dtoJHyywA";
                v.SecretKey = "puND54oD59";
                v.Sign = "8DgJiUojSpWnHYq";
                v.Username = "jTrp";
                v.ApiKey = "cgE82IQx6OFCe";
                v.EntId = "sgoRDF";
                v.RobotNum = "CIu96YUAhouiLAOzB";
                v.OutCallers = "ycw16PiR";
                v.CreateBy = "75sGVOMn9RVPtxddk";
                v.CreateUser = "oiwbTdXlZw";
                v.SurplusAmount = 75;
                v.UnitPrice = 17;
                v.CallInterval = 28;
                context.Set<Business_OutboundSetting>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_OutboundSettingVM));

            Business_OutboundSettingVM vm = rv.Model as Business_OutboundSettingVM;
            v = new Business_OutboundSetting();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_OutboundSetting>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Business_OutboundSetting v = new Business_OutboundSetting();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.IsCall = true;
                v.EcName = "4wWu";
                v.ApId = "1Hn6dtoJHyywA";
                v.SecretKey = "puND54oD59";
                v.Sign = "8DgJiUojSpWnHYq";
                v.Username = "jTrp";
                v.ApiKey = "cgE82IQx6OFCe";
                v.EntId = "sgoRDF";
                v.RobotNum = "CIu96YUAhouiLAOzB";
                v.OutCallers = "ycw16PiR";
                v.CreateBy = "75sGVOMn9RVPtxddk";
                v.CreateUser = "oiwbTdXlZw";
                v.SurplusAmount = 75;
                v.UnitPrice = 17;
                v.CallInterval = 28;
                context.Set<Business_OutboundSetting>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Business_OutboundSetting v1 = new Business_OutboundSetting();
            Business_OutboundSetting v2 = new Business_OutboundSetting();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.IsCall = true;
                v1.EcName = "4wWu";
                v1.ApId = "1Hn6dtoJHyywA";
                v1.SecretKey = "puND54oD59";
                v1.Sign = "8DgJiUojSpWnHYq";
                v1.Username = "jTrp";
                v1.ApiKey = "cgE82IQx6OFCe";
                v1.EntId = "sgoRDF";
                v1.RobotNum = "CIu96YUAhouiLAOzB";
                v1.OutCallers = "ycw16PiR";
                v1.CreateBy = "75sGVOMn9RVPtxddk";
                v1.CreateUser = "oiwbTdXlZw";
                v1.SurplusAmount = 75;
                v1.UnitPrice = 17;
                v1.CallInterval = 28;
                v2.IsCall = false;
                v2.EcName = "SR88cC";
                v2.ApId = "yZ";
                v2.SecretKey = "jHU";
                v2.Sign = "4rAqE8LRr9NvZhl65qZ";
                v2.Username = "3";
                v2.ApiKey = "ZVVD64MEH";
                v2.EntId = "tmiRN68ksNyC";
                v2.RobotNum = "hgTLKD";
                v2.OutCallers = "9xUBBbCVhfSAP6";
                v2.CreateBy = "Hs4sEPlO";
                v2.CreateUser = "6";
                v2.SurplusAmount = 24;
                v2.UnitPrice = 78;
                v2.CallInterval = 0;
                context.Set<Business_OutboundSetting>().Add(v1);
                context.Set<Business_OutboundSetting>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_OutboundSettingBatchVM));

            Business_OutboundSettingBatchVM vm = rv.Model as Business_OutboundSettingBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_OutboundSetting>().Find(v1.ID);
                var data2 = context.Set<Business_OutboundSetting>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Business_OutboundSetting v1 = new Business_OutboundSetting();
            Business_OutboundSetting v2 = new Business_OutboundSetting();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.IsCall = true;
                v1.EcName = "4wWu";
                v1.ApId = "1Hn6dtoJHyywA";
                v1.SecretKey = "puND54oD59";
                v1.Sign = "8DgJiUojSpWnHYq";
                v1.Username = "jTrp";
                v1.ApiKey = "cgE82IQx6OFCe";
                v1.EntId = "sgoRDF";
                v1.RobotNum = "CIu96YUAhouiLAOzB";
                v1.OutCallers = "ycw16PiR";
                v1.CreateBy = "75sGVOMn9RVPtxddk";
                v1.CreateUser = "oiwbTdXlZw";
                v1.SurplusAmount = 75;
                v1.UnitPrice = 17;
                v1.CallInterval = 28;
                v2.IsCall = false;
                v2.EcName = "SR88cC";
                v2.ApId = "yZ";
                v2.SecretKey = "jHU";
                v2.Sign = "4rAqE8LRr9NvZhl65qZ";
                v2.Username = "3";
                v2.ApiKey = "ZVVD64MEH";
                v2.EntId = "tmiRN68ksNyC";
                v2.RobotNum = "hgTLKD";
                v2.OutCallers = "9xUBBbCVhfSAP6";
                v2.CreateBy = "Hs4sEPlO";
                v2.CreateUser = "6";
                v2.SurplusAmount = 24;
                v2.UnitPrice = 78;
                v2.CallInterval = 0;
                context.Set<Business_OutboundSetting>().Add(v1);
                context.Set<Business_OutboundSetting>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_OutboundSettingBatchVM));

            Business_OutboundSettingBatchVM vm = rv.Model as Business_OutboundSettingBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_OutboundSetting>().Find(v1.ID);
                var data2 = context.Set<Business_OutboundSetting>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }


    }
}
