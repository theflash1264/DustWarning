using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Business.Business_AlarmVMs;
using DustWarning.Model.Business;
using DustWarning.DataAccess;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.Test
{
    [TestClass]
    public class Business_AlarmControllerTest
    {
        private Business_AlarmController _controller;
        private string _seed;

        public Business_AlarmControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Business_AlarmController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Business_AlarmListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Business_AlarmVM));

            Business_AlarmVM vm = rv.Model as Business_AlarmVM;
            Business_Alarm v = new Business_Alarm();
			
            v.DeviceId = AddBasis_Device();
            v.AlarmId = AddSys_Dictionary();
            v.AlarmInformation = "luswMMo8";
            v.StarTime = DateTime.Parse("2024-09-04 14:27:02");
            v.EndTime = DateTime.Parse("2024-09-23 14:27:02");
            v.Continued = 81;
            v.State = 68;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Alarm>().Find(v.ID);
				
                Assert.AreEqual(data.AlarmInformation, "luswMMo8");
                Assert.AreEqual(data.StarTime, DateTime.Parse("2024-09-04 14:27:02"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2024-09-23 14:27:02"));
                Assert.AreEqual(data.Continued, 81);
                Assert.AreEqual(data.State, 68);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Business_Alarm v = new Business_Alarm();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DeviceId = AddBasis_Device();
                v.AlarmId = AddSys_Dictionary();
                v.AlarmInformation = "luswMMo8";
                v.StarTime = DateTime.Parse("2024-09-04 14:27:02");
                v.EndTime = DateTime.Parse("2024-09-23 14:27:02");
                v.Continued = 81;
                v.State = 68;
                context.Set<Business_Alarm>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_AlarmVM));

            Business_AlarmVM vm = rv.Model as Business_AlarmVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Business_Alarm();
            v.ID = vm.Entity.ID;
       		
            v.AlarmInformation = "1zRnXPAEE889f9";
            v.StarTime = DateTime.Parse("2024-11-29 14:27:02");
            v.EndTime = DateTime.Parse("2023-07-24 14:27:02");
            v.Continued = 91;
            v.State = 30;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DeviceId", "");
            vm.FC.Add("Entity.AlarmId", "");
            vm.FC.Add("Entity.AlarmInformation", "");
            vm.FC.Add("Entity.StarTime", "");
            vm.FC.Add("Entity.EndTime", "");
            vm.FC.Add("Entity.Continued", "");
            vm.FC.Add("Entity.State", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Alarm>().Find(v.ID);
 				
                Assert.AreEqual(data.AlarmInformation, "1zRnXPAEE889f9");
                Assert.AreEqual(data.StarTime, DateTime.Parse("2024-11-29 14:27:02"));
                Assert.AreEqual(data.EndTime, DateTime.Parse("2023-07-24 14:27:02"));
                Assert.AreEqual(data.Continued, 91);
                Assert.AreEqual(data.State, 30);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Business_Alarm v = new Business_Alarm();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DeviceId = AddBasis_Device();
                v.AlarmId = AddSys_Dictionary();
                v.AlarmInformation = "luswMMo8";
                v.StarTime = DateTime.Parse("2024-09-04 14:27:02");
                v.EndTime = DateTime.Parse("2024-09-23 14:27:02");
                v.Continued = 81;
                v.State = 68;
                context.Set<Business_Alarm>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_AlarmVM));

            Business_AlarmVM vm = rv.Model as Business_AlarmVM;
            v = new Business_Alarm();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_Alarm>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Business_Alarm v = new Business_Alarm();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DeviceId = AddBasis_Device();
                v.AlarmId = AddSys_Dictionary();
                v.AlarmInformation = "luswMMo8";
                v.StarTime = DateTime.Parse("2024-09-04 14:27:02");
                v.EndTime = DateTime.Parse("2024-09-23 14:27:02");
                v.Continued = 81;
                v.State = 68;
                context.Set<Business_Alarm>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Business_Alarm v1 = new Business_Alarm();
            Business_Alarm v2 = new Business_Alarm();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.AlarmId = AddSys_Dictionary();
                v1.AlarmInformation = "luswMMo8";
                v1.StarTime = DateTime.Parse("2024-09-04 14:27:02");
                v1.EndTime = DateTime.Parse("2024-09-23 14:27:02");
                v1.Continued = 81;
                v1.State = 68;
                v2.DeviceId = v1.DeviceId; 
                v2.AlarmId = v1.AlarmId; 
                v2.AlarmInformation = "1zRnXPAEE889f9";
                v2.StarTime = DateTime.Parse("2024-11-29 14:27:02");
                v2.EndTime = DateTime.Parse("2023-07-24 14:27:02");
                v2.Continued = 91;
                v2.State = 30;
                context.Set<Business_Alarm>().Add(v1);
                context.Set<Business_Alarm>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_AlarmBatchVM));

            Business_AlarmBatchVM vm = rv.Model as Business_AlarmBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_Alarm>().Find(v1.ID);
                var data2 = context.Set<Business_Alarm>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Business_Alarm v1 = new Business_Alarm();
            Business_Alarm v2 = new Business_Alarm();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.AlarmId = AddSys_Dictionary();
                v1.AlarmInformation = "luswMMo8";
                v1.StarTime = DateTime.Parse("2024-09-04 14:27:02");
                v1.EndTime = DateTime.Parse("2024-09-23 14:27:02");
                v1.Continued = 81;
                v1.State = 68;
                v2.DeviceId = v1.DeviceId; 
                v2.AlarmId = v1.AlarmId; 
                v2.AlarmInformation = "1zRnXPAEE889f9";
                v2.StarTime = DateTime.Parse("2024-11-29 14:27:02");
                v2.EndTime = DateTime.Parse("2023-07-24 14:27:02");
                v2.Continued = 91;
                v2.State = 30;
                context.Set<Business_Alarm>().Add(v1);
                context.Set<Business_Alarm>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_AlarmBatchVM));

            Business_AlarmBatchVM vm = rv.Model as Business_AlarmBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_Alarm>().Find(v1.ID);
                var data2 = context.Set<Business_Alarm>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Business_AlarmListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "SPJqBQ5kY5";
                v.Code = "Djd7Kws";
                context.Set<Sys_Dictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_DeviceType()
        {
            Basis_DeviceType v = new Basis_DeviceType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "TP0V7";
                v.MessageTypeId = AddSys_Dictionary();
                v.AgreementTypeId = AddSys_Dictionary();
                context.Set<Basis_DeviceType>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddSys_AreaDictionary()
        {
            Sys_AreaDictionary v = new Sys_AreaDictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "Crw85t";
                v.AreaCode = "WDjeYjmcyk";
                context.Set<Sys_AreaDictionary>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_Area()
        {
            Basis_Area v = new Basis_Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "9giz2G";
                v.AreaCode = "JVfef";
                v.Lng = "caXzvZGL1w7Ubz0k";
                v.Lat = "1S";
                v.Remarks = "WGmy";
                v.AreaId = AddSys_AreaDictionary();
                v.ProvinceId = AddSys_AreaDictionary();
                v.CityId = AddSys_AreaDictionary();
                context.Set<Basis_Area>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_Device()
        {
            Basis_Device v = new Basis_Device();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "GfvDlZ7";
                v.Code = "Fc3ZgR7bHmFEv2mdpHH";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "xAA4vWr7";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
