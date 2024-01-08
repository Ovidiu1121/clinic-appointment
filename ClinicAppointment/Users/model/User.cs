using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.model
{
    public class User : IUserBuilder, IComparable<User>
    {
        private Int32 id;
        private String name;
        private String email;
        private String password;
        private String phone;
        private int appointmentDuration;
        private int workStartTime;
        private int workEndTime;

        private UserType type;


        #region CONSTRUCTORS

        public User(Int32 id, String name, String email, String password, String phone, UserType type)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.type = type;
        }
        public User(Int32 id, String name, String email, String password, String phone, UserType type,int appointmentDuration,int workStartTime,int workEndTime)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.type = type;
            this.appointmentDuration = appointmentDuration;
            this.workStartTime = workStartTime;
            this.workEndTime = workEndTime;
        }

        public User(User user)
        {
            this.id = user.id;
            this.name = user.name;
            this.email = user.email;
            this.password = user.password;
            this.phone = user.phone;
            this.type = user.type;
        }

        public User()
        {
            this.id = -1;
            this.name = "name";
            this.email = "email";
            this.password = "1234";
            this.phone = "phone";
            this.type = UserType.NONE;
        }

        #endregion

        #region ACCESSORS

        public Int32 GetId() { return this.id; }

        public String GetName() { return this.name; }

        public String GetEmail() { return this.email; }

        public String GetPassword() { return this.password; }

        public String GetPhone() { return this.phone; }

        public UserType GetType() { return this.type; }

        public int GetAppointmentDuration() { return this.appointmentDuration; }

        public int GetWorkStartTime() { return this.workStartTime; }

        public int GetWorkEndTime() { return this.workEndTime; }

        public void SetId(Int32 id) { this.id = id; }

        public void SetName(String name) { this.name = name; }

        public void SetEmail(String email) { this.email = email; }

        public void SetPassword(String password) { this.password = password; }

        public void SetPhone(String phone) { this.phone = phone; }

        public void SetType(UserType type) { this.type = type; }

        public void SetAppointmentDuration(int appointmentDuration) { this.appointmentDuration = appointmentDuration;}

        public void SetWorkStartTime(int workStartTime) { this.workStartTime = workStartTime;}

        public void SetWorkEndTime(int workEndTime) { this.workEndTime = workEndTime;}

        #endregion

        #region BUILDER

        public User Id(Int32 id)
        {
            this.id = id;
            return this;
        }

        public User Name(String name)
        {
            this.name = name;
            return this;
        }

        public User Email(String email)
        {
            this.email = email;
            return this;
        }

        public User Password(string password)
        {
            this.password = password;
            return this;
        }

        public User Phone(String phone)
        {
            this.phone = phone;
            return this;
        }

        public User Type(UserType type)
        {
            this.type = type;
            return this;
        }
        public User AppointmentDuration(int appointmentDuration)
        {
            this.appointmentDuration=appointmentDuration;
            return this;
        }
        public User WorkStartTime(int workStartTime)
        {
            this.workStartTime = workStartTime;
            return this;
        }
        public User WorkEndTime(int workEndTime)
        {
            this.workEndTime = workEndTime;
            return this;
        }


        #endregion

        #region PUBLIC_METHODS

        public override Boolean Equals(object obj)
        {
            User user = obj as User;
            return user.email == this.email && user.phone == this.phone;
        }

        public override String ToString()
        {
            String desc = "";
            desc += $"Name : {this.name}\n";
            desc += $"Email : {this.email}\n";
            desc += $"Phone : {this.phone}\n";
            return desc;
        }

        public String ToStringAdmin()
        {
            String desc = "";
            desc += $"Id : {this.id}\n";
            desc += $"Name : {this.name}\n";
            desc += $"Email : {this.email}\n";
            desc += $"Phone : {this.phone}\n";
            desc += $"Role : {this.type}\n";
            return desc;
        }

        public String ToStringAdminNoRole()
        {
            String desc = "";
            desc += $"Id : {this.id}\n";
            desc += $"Name : {this.name}\n";
            desc += $"Email : {this.email}\n";
            desc += $"Phone : {this.phone}\n";
            return desc;
        }

        public override Int32 GetHashCode()
        {
            return (int)Math.Pow(this.id, this.email.Length / 2) + this.name.Length * 3;
        }

        public Int32 CompareTo(User user)
        {
            if (this.id > user.id)
            {
                return 1;
            }
            else if (this.id == user.id)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public User Clone()
        {
            return new User(this);
        }

        public static User BuildUser()
        {
            return new User();
        }
        #endregion  
    }
}
