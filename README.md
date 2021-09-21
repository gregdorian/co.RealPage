# co.RealPage
prueba tecnica


    public string GetFullName()
    {
        return $"{LastName}, {FirstName}";
    }
    
    para obtener  nombres completos

profiling a model w/ address

    public class UserProfile : Profile
     {
       public UserProfile()
       {
         CreateMap<User, UserViewModel>().IncludeMembers(u => u.Address, u => u.AdditionalInfo);
         CreateMap<Address, UserViewModel>(MemberList.None);
         CreateMap<AdditionalInfo, UserViewModel>(MemberList.None);
       }
     }

the model

     public class User
      {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }
        public string GetFullName()
      {
        return $"{LastName}, {FirstName}";
       }
    }
