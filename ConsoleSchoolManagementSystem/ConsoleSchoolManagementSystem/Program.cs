using BLL.Implementation;
using ConsoleSchoolManagementSystem;

UserAuthService userAuthService = new UserAuthService();
userAuthService.InitializedData();

Controller controller = new Controller();
controller.Run();
