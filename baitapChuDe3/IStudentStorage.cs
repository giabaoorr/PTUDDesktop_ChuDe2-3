using System.Collections.Generic;

namespace baitapChuDe3
{
    /// <summary>
    /// Giao diện dùng chung cho các lớp đọc/ghi danh sách sinh viên (Tính đa hình)
    /// </summary>
    public interface IStudentStorage
    {
        List<Student> Read(string filePath);
        void Write(string filePath, List<Student> students);
    }
}
