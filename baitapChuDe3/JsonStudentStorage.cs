using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace baitapChuDe3
{
    /// <summary>
    /// Lớp đọc/ghi danh sách sinh viên định dạng JSON sử dụng Newtonsoft.Json
    /// </summary>
    public class JsonStudentStorage : IStudentStorage
    {
        public List<Student> Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Student>();
            }

            try
            {
                string json = File.ReadAllText(filePath, Encoding.UTF8);
                var list = JsonConvert.DeserializeObject<List<Student>>(json);
                return list ?? new List<Student>();
            }
            catch
            {
                return new List<Student>();
            }
        }

        public void Write(string filePath, List<Student> students)
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }
    }
}
