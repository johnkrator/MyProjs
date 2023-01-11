namespace BLL.Interfaces;

public interface IOperations
{
    void Session();
    void FeesPayment();
    void GenerateSchoolFeesReceipt();
    void PrintSchoolFees();
    void BookHostelSpace();
    void RegisterCourses();
    void GenerateCourseRegForm();
    void PrintCourseForm();
}
