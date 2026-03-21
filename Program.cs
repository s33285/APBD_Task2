using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using APBD_TASK2.Services;
using APBD_TASK2.Database;

var service = new RentalService();

var student = new User("John", "Doe", "s32393@pjwstk.edu.pl", UserType.Student);
var employee = new User("Janny", "Smith", "janny@gmail.com", UserType.Employee);

service.AddUser(student);
service.AddUser(employee);

var laptop = new Laptop("Dell", "Office laptop", 16, "i7");
var camera = new Camera("Canon", "DSLR camera", 24, true);

service.AddEquipment(laptop);
service.AddEquipment(camera);


service.RentEquipment(student.Id, laptop.Id, 3);


try
{
    service.RentEquipment(employee.Id, laptop.Id, 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

service.ReturnEquipment(laptop.Id);


Console.WriteLine(service.GenerateReport());

Console.ReadLine();