using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DustWarning.Controllers;
using DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs;
using DustWarning.Model.Basis;
using DustWarning.DataAccess;


namespace DustWarning.Test
{
    [TestClass]
    public class Basis_MonitorFactorControllerTest
    {
        private Basis_MonitorFactorController _controller;
        private string _seed;

        public Basis_MonitorFactorControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<Basis_MonitorFactorController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as Basis_MonitorFactorListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_MonitorFactorVM));

            Basis_MonitorFactorVM vm = rv.Model as Basis_MonitorFactorVM;
            Basis_MonitorFactor v = new Basis_MonitorFactor();
			
            v.DeviceId = AddBasis_Device();
            v.MonitorFactorId = AddBasis_DetectionItme();
            v.MaxNum = 36;
            v.MinNum = 96;
            v.IsZeroAlarm = 37;
            v.ZeroAlarmDuration = 44;
            v.IsConstantAlarm = 58;
            v.ConstantAlarmDuration = 90;
            v.Sort = 62;
            v.IsShow = 83;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_MonitorFactor>().Find(v.ID);
				
                Assert.AreEqual(data.MaxNum, 36);
                Assert.AreEqual(data.MinNum, 96);
                Assert.AreEqual(data.IsZeroAlarm, 37);
                Assert.AreEqual(data.ZeroAlarmDuration, 44);
                Assert.AreEqual(data.IsConstantAlarm, 58);
                Assert.AreEqual(data.ConstantAlarmDuration, 90);
                Assert.AreEqual(data.Sort, 62);
                Assert.AreEqual(data.IsShow, 83);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Basis_MonitorFactor v = new Basis_MonitorFactor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DeviceId = AddBasis_Device();
                v.MonitorFactorId = AddBasis_DetectionItme();
                v.MaxNum = 36;
                v.MinNum = 96;
                v.IsZeroAlarm = 37;
                v.ZeroAlarmDuration = 44;
                v.IsConstantAlarm = 58;
                v.ConstantAlarmDuration = 90;
                v.Sort = 62;
                v.IsShow = 83;
                context.Set<Basis_MonitorFactor>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_MonitorFactorVM));

            Basis_MonitorFactorVM vm = rv.Model as Basis_MonitorFactorVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Basis_MonitorFactor();
            v.ID = vm.Entity.ID;
       		
            v.MaxNum = 19;
            v.MinNum = 42;
            v.IsZeroAlarm = 96;
            v.ZeroAlarmDuration = 20;
            v.IsConstantAlarm = 46;
            v.ConstantAlarmDuration = 77;
            v.Sort = 94;
            v.IsShow = 94;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DeviceId", "");
            vm.FC.Add("Entity.MonitorFactorId", "");
            vm.FC.Add("Entity.MaxNum", "");
            vm.FC.Add("Entity.MinNum", "");
            vm.FC.Add("Entity.IsZeroAlarm", "");
            vm.FC.Add("Entity.ZeroAlarmDuration", "");
            vm.FC.Add("Entity.IsConstantAlarm", "");
            vm.FC.Add("Entity.ConstantAlarmDuration", "");
            vm.FC.Add("Entity.Sort", "");
            vm.FC.Add("Entity.IsShow", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_MonitorFactor>().Find(v.ID);
 				
                Assert.AreEqual(data.MaxNum, 19);
                Assert.AreEqual(data.MinNum, 42);
                Assert.AreEqual(data.IsZeroAlarm, 96);
                Assert.AreEqual(data.ZeroAlarmDuration, 20);
                Assert.AreEqual(data.IsConstantAlarm, 46);
                Assert.AreEqual(data.ConstantAlarmDuration, 77);
                Assert.AreEqual(data.Sort, 94);
                Assert.AreEqual(data.IsShow, 94);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Basis_MonitorFactor v = new Basis_MonitorFactor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DeviceId = AddBasis_Device();
                v.MonitorFactorId = AddBasis_DetectionItme();
                v.MaxNum = 36;
                v.MinNum = 96;
                v.IsZeroAlarm = 37;
                v.ZeroAlarmDuration = 44;
                v.IsConstantAlarm = 58;
                v.ConstantAlarmDuration = 90;
                v.Sort = 62;
                v.IsShow = 83;
                context.Set<Basis_MonitorFactor>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_MonitorFactorVM));

            Basis_MonitorFactorVM vm = rv.Model as Basis_MonitorFactorVM;
            v = new Basis_MonitorFactor();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Basis_MonitorFactor>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Basis_MonitorFactor v = new Basis_MonitorFactor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DeviceId = AddBasis_Device();
                v.MonitorFactorId = AddBasis_DetectionItme();
                v.MaxNum = 36;
                v.MinNum = 96;
                v.IsZeroAlarm = 37;
                v.ZeroAlarmDuration = 44;
                v.IsConstantAlarm = 58;
                v.ConstantAlarmDuration = 90;
                v.Sort = 62;
                v.IsShow = 83;
                context.Set<Basis_MonitorFactor>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Basis_MonitorFactor v1 = new Basis_MonitorFactor();
            Basis_MonitorFactor v2 = new Basis_MonitorFactor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.MonitorFactorId = AddBasis_DetectionItme();
                v1.MaxNum = 36;
                v1.MinNum = 96;
                v1.IsZeroAlarm = 37;
                v1.ZeroAlarmDuration = 44;
                v1.IsConstantAlarm = 58;
                v1.ConstantAlarmDuration = 90;
                v1.Sort = 62;
                v1.IsShow = 83;
                v2.DeviceId = v1.DeviceId; 
                v2.MonitorFactorId = v1.MonitorFactorId; 
                v2.MaxNum = 19;
                v2.MinNum = 42;
                v2.IsZeroAlarm = 96;
                v2.ZeroAlarmDuration = 20;
                v2.IsConstantAlarm = 46;
                v2.ConstantAlarmDuration = 77;
                v2.Sort = 94;
                v2.IsShow = 94;
                context.Set<Basis_MonitorFactor>().Add(v1);
                context.Set<Basis_MonitorFactor>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_MonitorFactorBatchVM));

            Basis_MonitorFactorBatchVM vm = rv.Model as Basis_MonitorFactorBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_MonitorFactor>().Find(v1.ID);
                var data2 = context.Set<Basis_MonitorFactor>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Basis_MonitorFactor v1 = new Basis_MonitorFactor();
            Basis_MonitorFactor v2 = new Basis_MonitorFactor();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeviceId = AddBasis_Device();
                v1.MonitorFactorId = AddBasis_DetectionItme();
                v1.MaxNum = 36;
                v1.MinNum = 96;
                v1.IsZeroAlarm = 37;
                v1.ZeroAlarmDuration = 44;
                v1.IsConstantAlarm = 58;
                v1.ConstantAlarmDuration = 90;
                v1.Sort = 62;
                v1.IsShow = 83;
                v2.DeviceId = v1.DeviceId; 
                v2.MonitorFactorId = v1.MonitorFactorId; 
                v2.MaxNum = 19;
                v2.MinNum = 42;
                v2.IsZeroAlarm = 96;
                v2.ZeroAlarmDuration = 20;
                v2.IsConstantAlarm = 46;
                v2.ConstantAlarmDuration = 77;
                v2.Sort = 94;
                v2.IsShow = 94;
                context.Set<Basis_MonitorFactor>().Add(v1);
                context.Set<Basis_MonitorFactor>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(Basis_MonitorFactorBatchVM));

            Basis_MonitorFactorBatchVM vm = rv.Model as Basis_MonitorFactorBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Basis_MonitorFactor>().Find(v1.ID);
                var data2 = context.Set<Basis_MonitorFactor>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as Basis_MonitorFactorListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddSys_Dictionary()
        {
            Sys_Dictionary v = new Sys_Dictionary();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "QuKyPIH5qmmaYf";
                v.Code = "KJ3";
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

                v.Name = "JS5EipOU3TSo";
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

                v.Name = "RRteX4rV";
                v.AreaCode = "QMmnfx4kuGZrPr2wuw";
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

                v.Name = "9k6NiINe";
                v.AreaCode = "muL343eSfAduqI";
                v.Lng = "V1bXUzCdCiP8bTU7h0";
                v.Lat = "xTgI64kLMzRAGC4OZ2";
                v.Remarks = "9x";
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

                v.Name = "EmvBoP8h";
                v.Code = "eA";
                v.DTId = AddBasis_DeviceType();
                v.AreaId = AddBasis_Area();
                v.Place = "3znkKwGgeIvrpc";
                context.Set<Basis_Device>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddBasis_DetectionItme()
        {
            Basis_DetectionItme v = new Basis_DetectionItme();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "o246YaBs";
                v.Code = "1";
                v.UDictionaryId = AddSys_Dictionary();
                context.Set<Basis_DetectionItme>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
