using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTest
{
    public class ModbusT
    {
        /// <summary>
        /// 读线圈状态测试
        /// </summary>
        public static void Test_0x01()
        {
            ushort startAddr = 0;
            ushort readLen = 10;

            var a = BitConverter.GetBytes(readLen);

            // 请求
            // byte[] 需要指定长度；不支持Linq
            List<byte> command = new List<byte>();
            command.Add(0x01);// 1号从站
            command.Add(0x01);// 功能码：读线圈状态
                              // 起始地址
            command.Add(BitConverter.GetBytes(startAddr)[1]);//
            command.Add(BitConverter.GetBytes(startAddr)[0]);
            // 读取数量
            command.Add(BitConverter.GetBytes(readLen)[1]);
            command.Add(BitConverter.GetBytes(readLen)[0]);

            // CRC
            command = CRC16(command);

            // 报文组装完成
            // 发送-》SerialPort
            SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            // 打开串口
            serialPort.Open();

            serialPort.Write(command.ToArray(), 0, command.Count);

            // 进行响应报文的接收和解析
            byte[] respBytes = new byte[serialPort.BytesToRead];
            serialPort.Read(respBytes, 0, respBytes.Length);

            // respBytes -> 01 01 02 00 00 B9 FC
            // 检查一个校验位
            List<byte> respList = new List<byte>(respBytes);
            respList.RemoveRange(0, 3);//截去：从站地址  功能码  字节计数
            respList.RemoveRange(respList.Count - 2, 2);//截去：校验位

            respList.Reverse();
            var respStrList = respList.Select(r => Convert.ToString(r, 2)).ToList();
            var values = string.Join("", respStrList).ToList();
            values.Reverse();
            values.ForEach(c => Console.WriteLine(Convert.ToBoolean(int.Parse(c.ToString()))));

        }
        /// <summary>
        /// 读保持型寄存器
        /// </summary>
        public static void Test_0x03()
        {
            ushort startAddr = 0;
            ushort readLen = 10;

            // 请求
            // byte[] 需要指定长度；不支持Linq
            List<byte> command = new List<byte>();
            command.Add(0x01);// 1号从站
            command.Add(0x03);// 功能码：读保持型寄存器
                              // 起始地址
            command.Add(BitConverter.GetBytes(startAddr)[1]);
            command.Add(BitConverter.GetBytes(startAddr)[0]);
            // 读取数量
            command.Add(BitConverter.GetBytes(readLen)[1]);
            command.Add(BitConverter.GetBytes(readLen)[0]);

            // CRC
            command = CRC16(command);

            // 报文组装完成
            // 发送-》SerialPort
            SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            // 打开串口
            serialPort.Open();

            serialPort.Write(command.ToArray(), 0, command.Count);

            // 进行响应报文的接收和解析
            byte[] respBytes = new byte[serialPort.BytesToRead];
            serialPort.Read(respBytes, 0, respBytes.Length);

            // respBytes -> 01 01 02 00 00 B9 FC
            // 检查一个校验位
            List<byte> respList = new List<byte>(respBytes);
            respList.RemoveRange(0, 3);//截去：从站地址  功能码  字节计数
            respList.RemoveRange(respList.Count - 2, 2);//截去：校验位


            // 拿到实际的数据部分，进行数据解析
            // 明确一点：读的是无符号单精度
            //byte[] data = new byte[2];
            //for (int i = 0; i < readLen; i++)
            //{
            //    // 字节序问题    小端   大端
            //    data[0] = respList[i * 2 + 1];
            //    data[1] = respList[i * 2];
            //    // 根据此两个字节转换成想要的实际数字
            //    var value = BitConverter.ToUInt16(data, 0);
            //    Console.WriteLine(value);
            //}



            // 明确一点：读的是Float
            byte[] data = new byte[4];
            for (int i = 0; i < readLen / 2; i++)
            {
                // 字节序问题    小端   大端
                data[0] = respList[i * 4 + 3];
                data[1] = respList[i * 4 + 2];
                data[2] = respList[i * 4 + 1];
                data[3] = respList[i * 4];
                // 根据此两个字节转换成想要的实际数字
                var value = BitConverter.ToSingle(data, 0);
                Console.WriteLine(value);
            }
        }
        /// <summary>
        /// 写多个保持型寄存器
        /// </summary>
        public static void Test_0x10()
        {
            ushort startAddr = 2;
            ushort writeLen = 4;
            float[] values = new float[] { 123.45f, 14.3f };

            // 请求
            // byte[] 需要指定长度；不支持Linq
            List<byte> command = new List<byte>();
            command.Add(0x01);// 1号从站
            command.Add(0x10);// 功能码：写多个保持型寄存器
                              // 写入地址
            command.Add(BitConverter.GetBytes(startAddr)[1]);
            command.Add(BitConverter.GetBytes(startAddr)[0]);
            // 写入数量
            command.Add(BitConverter.GetBytes(writeLen)[1]);
            command.Add(BitConverter.GetBytes(writeLen)[0]);


            // 获取数值的byte[]
            List<byte> valueBytes = new List<byte>();
            for (int i = 0; i < values.Length; i++)
            {
                List<byte> temp = new List<byte>(BitConverter.GetBytes(values[i]));
                temp.Reverse();// 调整字节序
                valueBytes.AddRange(temp);
            }

            // 字节数
            command.Add((byte)valueBytes.Count);
            command.AddRange(valueBytes);

            // CRC
            command = CRC16(command);

            // 报文组装完成
            // 发送-》SerialPort
            SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            // 打开串口
            serialPort.Open();

            serialPort.Write(command.ToArray(), 0, command.Count);
        }
        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="value"></param>
        /// <param name="poly"></param>
        /// <param name="crcInit"></param>
        /// <returns></returns>
        static List<byte> CRC16(List<byte> value, ushort poly = 0xA001, ushort crcInit = 0xFFFF)
        {
            if (value == null || !value.Any())
                throw new ArgumentException("");

            //运算
            ushort crc = crcInit;
            for (int i = 0; i < value.Count; i++)
            {
                crc = (ushort)(crc ^ (value[i]));
                for (int j = 0; j < 8; j++)
                {
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ poly) : (ushort)(crc >> 1);
                }
            }
            byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
            byte lo = (byte)(crc & 0x00FF);         //低位置

            List<byte> buffer = new List<byte>();
            //添加校验原始值
            buffer.AddRange(value);
            //添加校验位值
            buffer.Add(lo);
            buffer.Add(hi);

            //加上原始校验值返回
            return buffer;
        }
    }
}
