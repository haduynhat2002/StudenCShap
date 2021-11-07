using MySql.Data.MySqlClient;
using StudentCShap.Entities;
using StudentCShap.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCShap.Models
{
    class StudentModel : IStudentModel
    {
        private static string InsertCommad =
            "insert into students" +
            "(roll_number, full_name, avatar, email, birthday, phone, address, gender, created_at, update_at, status" +
            "value" +
            "(@rollNumber, @fullName, @avatar, @email, @birthday, @phone, @address, @gender, @createAt, @updateAt, @status)";
        private static string SeclecCommad = "selec * form students";

        public bool save(Student student) {
            using (var connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                var mysqlCommand = new MySqlCommand(InsertCommad, connection);
                mysqlCommand.Parameters.AddWithValue("@rollNumber", student.RollNumber);
                mysqlCommand.Parameters.AddWithValue("@fullName", student.FullName);
                mysqlCommand.Parameters.AddWithValue("@avatar", student.Avatar);
                mysqlCommand.Parameters.AddWithValue("@email", student.Email);
                mysqlCommand.Parameters.AddWithValue("@birthday", student.Birthday.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@phone", student.Phone);
                mysqlCommand.Parameters.AddWithValue("@address", student.Address);
                mysqlCommand.Parameters.AddWithValue("@gender", student.Gender);
                mysqlCommand.Parameters.AddWithValue("@createAt", student.CreateAt.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@updateAt", student.UpdateAt.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@status", student.Status);
                // thuc thi
                mysqlCommand.ExecuteNonQuery();
                //try with recource  using
                Console.WriteLine("Luu sinh vien thanh cong");
                return true;
            }
            return false;
        }
        public List<Student> FindAll() // co hay khong du lieu cung cha ve mot list rong
        {
            //tao danh sach rong
            List<Student> result = new List<Student>();
            // tao ket noi database 
            using (var connection = ConnectionHelper.GetConnection())
            {
                //mo ket noi 
                connection.Open();
                //tao cau lenh  truy van tu ket noi o tren
                var mysplCommand = new MySqlCommand(SeclecCommad, connection);
                // thuc thi, lay giu lieu tra ve
                var reader = mysplCommand.ExecuteReader(); // resultSet (java)
                while (reader.Read())
                {
                    var rollNumber = reader.GetString("roll_number");
                    var fullName = reader.GetString("full_name");
                    var avatar = reader.GetString("avatar");
                    var email = reader.GetString("email");
                    var birthday = reader.GetDateTime("birthday");
                    var phone = reader.GetInt32("phone");
                    var address = reader.GetString("address");
                    var gender = reader.GetInt32("gender");
                    var createAt = reader.GetDateTime("create_at");
                    var updateAt = reader.GetDateTime("update_at");
                    var status = reader.GetInt32("status");
                    //tao doi tuong student tu gia tri lay ve
                    var student = new Student
                    {
                        RollNumber = rollNumber,
                        FullName = fullName,
                        Avatar = avatar,
                        Email = email,
                        Birthday = birthday,
                        Phone = phone,
                        Address = address,
                        Gender = gender,
                        CreateAt = createAt,
                        UpdateAt = updateAt,
                        Status = status,
                    };
                    result.Add(student);
                }
            }
            return result;
        }
    }
}
