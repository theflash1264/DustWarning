using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Business.Business_LineCheckVMs;
using DustWarning.Model.Business;
using DustWarning.DataAccess;
using DustWarning.Model.Basis;


namespace DustWarning.Test
{
    [TestClass]
    public class Business_LineCheckControllerTest
    {
        private Business_LineCheckController _controller;
        private string _seed;

        public Business_LineCheckControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Business_LineCheckController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Business_LineCheckListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Business_LineCheckVM));

            Business_LineCheckVM vm = rv.Model as Business_LineCheckVM;
            Business_LineCheck v = new Business_LineCheck();
			
            v.DeviceId = AddBasis_Device();
            v.FrameworkUserId = AddFrameworkUser();
            v.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
            v.Situation = "NWKLZ6Eg";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_LineCheck>().Find(v.ID);
				
                Assert.AreEqual(data.CheckTime, DateTime.Parse("2023-02-06 14:28:56"));
                Assert.AreEqual(data.Situation, "NWKLZ6Eg");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Business_LineCheck v = new Business_LineCheck();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DeviceId = AddBasis_Device();
                v.FrameworkUserId = AddFrameworkUser();
                v.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
                v.Situation = "NWKLZ6Eg";
                context.Set<Business_LineCheck>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_LineCheckVM));

            Business_LineCheckVM vm = rv.Model as Business_LineCheckVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Business_LineCheck();
            v.ID = vm.Entity.ID;
       		
            v.CheckTime = DateTime.Parse("2022-09-30 14:28:56");
            v.Situation = "XGxdB";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DeviceId", "");
            vm.FC.Add("Entity.FrameworkUserId", "");
            vm.FC.Add("Entity.CheckTime", "");
            vm.FC.Add("Entity.Situation", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_LineCheck>().Find(v.ID);
 				
                Assert.AreEqual(data.CheckTime, DateTime.Parse("2022-09-30 14:28:56"));
                Assert.AreEqual(data.Situation, "XGxdB");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Business_LineCheck v = new Business_LineCheck();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DeviceId = AddBasis_Device();
                v.FrameworkUserId = AddFrameworkUser();
                v.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
                v.Situation = "NWKLZ6Eg";
                context.Set<Business_LineCheck>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Business_LineCheckVM));

            Business_LineCheckVM vm = rv.Model as Business_LineCheckVM;
            v = new Business_LineCheck();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Business_LineCheck>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Business_LineCheck v = new Business_LineCheck();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DeviceId = AddBasis_Device();
                v.FrameworkUserId = AddFrameworkUser();
                v.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
                v.Situation = "NWKLZ6Eg";
                context.Set<Business_LineCheck>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Business_LineCheck v1 = new Business_LineCheck();
            Business_LineCheck v2 = new Business_LineCheck();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.FrameworkUserId = AddFrameworkUser();
                v1.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
                v1.Situation = "NWKLZ6Eg";
                v2.DeviceId = v1.DeviceId; 
                v2.FrameworkUserId = v1.FrameworkUserId; 
                v2.CheckTime = DateTime.Parse("2022-09-30 14:28:56");
                v2.Situation = "XGxdB";
                context.Set<Business_LineCheck>().Add(v1);
                context.Set<Business_LineCheck>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_LineCheckBatchVM));

            Business_LineCheckBatchVM vm = rv.Model as Business_LineCheckBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_LineCheck>().Find(v1.ID);
                var data2 = context.Set<Business_LineCheck>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Business_LineCheck v1 = new Business_LineCheck();
            Business_LineCheck v2 = new Business_LineCheck();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.FrameworkUserId = AddFrameworkUser();
                v1.CheckTime = DateTime.Parse("2023-02-06 14:28:56");
                v1.Situation = "NWKLZ6Eg";
                v2.DeviceId = v1.DeviceId; 
                v2.FrameworkUserId = v1.FrameworkUserId; 
                v2.CheckTime = DateTime.Parse("2022-09-30 14:28:56");
                v2.Situation = "XGxdB";
                context.Set<Business_LineCheck>().Add(v1);
                context.Set<Business_LineCheck>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Business_LineCheckBatchVM));

            Business_LineCheckBatchVM vm = rv.Model as Business_LineCheckBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Business_LineCheck>().Find(v1.ID);
                var data2 = context.Set<Business_LineCheck>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Business_LineCheckListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "rr";
                v.Code = "ruUKFVzQQCdX";
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

                v.Name = "Bd1H";
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

                v.Name = "HnApGZosROWAHM";
                v.AreaCode = "UTMkedeg45ovABTlF6";
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

                v.Name = "6SFSn4yPIcdzkn";
                v.AreaCode = "9knGtsD3kPFZvrNsIt";
                v.Lng = "hq";
                v.Lat = "cjwXHSjFMeJ1kbR4aHU";
                v.Remarks = "kb0zG1G";
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

                v.Name = "0pejmLv";
                v.Code = "Wj7e4yKxw";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "MY8cpO3SlPRxruzxd";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "i8H";
                v.FileExt = "Esv";
                v.Path = "QXFntlrm5tc";
                v.Length = 77;
                v.UploadTime = DateTime.Parse("2024-10-05 14:28:56");
                v.SaveMode = "o";
                v.ExtraInfo = "ckxl6UkmQa2S";
                v.HandlerInfo = "E";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFrameworkUser()
        {
            FrameworkUser v = new FrameworkUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Email = "geZZM54Q6TzZXWANlyAxq1yGxXz";
                v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
                v.CellPhone = "SKJbkwpDLv9myrq";
                v.HomePhone = "3pZuSsl7Eh7lhrzvtRNSCTOD";
                v.Address = "oPI2PHcwszXPy5ffAfmjb4o4BPXdGpdVOk3h1013hhfagY4NIz2MBgnukO1At0pDWBANC9pBouC4YOWmVJVRxQTs8H7lI1Ii3bEfYqLJ";
                v.ZipCode = "5O";
                v.ITCode = "cOQlVaVRktecs0z2YaCY";
                v.Password = "BgrisvIdpiAGbtvF2bK856p3C9u";
                v.Name = "zVKHwCqAhLWYHTxp3bf";
                v.IsValid = true;
                v.PhotoId = AddFileAttachment();
                context.Set<FrameworkUser>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
