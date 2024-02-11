namespace Hello{

	class User{
		public string Name{get;set;}
		public string Email{get;set;}

		public User(){}
		
		public User(string name, string email){
			Name = name;
			Email = email;
		}
	}
	public class Open{
		public Open(){}

		void displayScreen(Open open,List<User> userList){
			Console.Clear();
			Console.WriteLine("Current User List\n");
			int length = userList.Count;
			if(length == 0){
				Console.WriteLine("No users found\n"); 
			}else{
				foreach(var user in userList){
					Console.WriteLine($"{user.Name},{user.Email}\n");
				}
			}			
			Console.WriteLine("List of options\n");
			Console.WriteLine("1) Add User\n");
			Console.WriteLine("2) Update User\n");
			Console.WriteLine("3) Delete User\n");
			Console.WriteLine("Enter your choice");
			int option = int.Parse(Console.ReadLine());		
			
			switch(option){
				case 0:
					Environment.Exit(0);
				break;
				case 1:
					userList = open.addUser(userList);
					open.displayScreen(open,userList);
				break;
				case 2:
					userList = open.updateUser(userList);
					open.displayScreen(open,userList);
				break;
				case 3:
					userList = open.deleteUser(userList);
					open.displayScreen(open,userList);
				break;
				default:
					Console.WriteLine("Invalid entry");
				break;
			}		
		}
		
		static void Main(string[] args){
			List<User> userList = new List<User>();
			Open open = new Open();
			open.displayScreen(open,userList);
		}
		
		List<User> addUser(List<User> userList){
			Console.Clear();
			Console.WriteLine("Enter user name and email\n");
			string name = Console.ReadLine();
			string email = Console.ReadLine();
			User newUser = new User(name,email);
			userList.Add(newUser);
			foreach(var user in userList){
				Console.WriteLine($"{user.Name},{user.Email}\n");
			}	
			return userList;
		}

		List<User> updateUser(List<User> userList){
			Console.Clear();
			Console.WriteLine("Enter the email of the user:");
			string email = Console.ReadLine();
			Console.WriteLine("\n Enter the updated user name and email");
			string updateName = Console.ReadLine();
			string updateEmail = Console.ReadLine();
			
			User updateUser = new User(updateName, updateEmail);
			List<User> filteredUser = new List<User>();
			foreach(var user in userList){
				if(!string.Equals(user.Email,email)){
					filteredUser.Add(user);
				}
			}
			filteredUser.Add(updateUser);
			return filteredUser;
			
		}

		List<User> deleteUser(List<User> userList){
			Console.Clear();
			Console.WriteLine("Enter the email of the user:");
			string email = Console.ReadLine();
			List<User> filteredUser = new List<User>();
			
			foreach(var user in userList){
				if(!string.Equals(user.Email,email)){
					filteredUser.Add(user);
				}
			}

			return filteredUser;
		}
	}
}
