using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace baitapChuDe3
{
    /// <summary>
    /// Lớp đọc/ghi danh sách sinh viên định dạng XML sử dụng XmlSerializer
    /// </summary>
    public class XmlStudentStorage : IStudentStorage
    {
        public List<Student> Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Student>();
            }

            try
            {
                var serializer = new XmlSerializer(typeof(List<Student>));
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    var result = serializer.Deserialize(reader) as List<Student>;
                    return result ?? new List<Student>();
                }
            }
            catch
            {
                return new List<Student>();
            }
        }

        public void Write(string filePath, List<Student> students)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, students);
            }
        }
    }
}
