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

// Displaying ALL equipment
Console.WriteLine("---Equipment---");
foreach(var e in service.GetAllEquipment())
    Console.WriteLine($"{e.Id}: {e.Name} - {e.Status}");

//Displaying Available equipment
Console.WriteLine("---Available Equipment---");
foreach (var e in service.GetAllAvailableEquipment())
    Console.WriteLine($"{e.Id}: {e.Name}");

//Correct rental
service.RentEquipment(student.Id, laptop.Id, 3);

//Invalid rental
try
{
    service.RentEquipment(employee.Id, laptop.Id, 2);
}
catch (Exception e)
{
    Console.WriteLine("Invalid rental attempt");
}

//Marking equipment unavailable
service.MarkEquipmentUnavailable(camera.Id);

try {
    service.RentEquipment(student.Id, camera.Id, 2);
} catch (Exception ex)
{
    Console.WriteLine("Unavailable equipment rental attempt");
}

//Show active rentals for student
Console.WriteLine("---Active Rentals for Student---");
var active = service.GetUserActiveRentals(student.Id);
foreach(var r in active)
    Console.WriteLine($"{r.Equipment.Name} rented until {r.DueDate}");

//Example of overdue rental
var rentalToModify = active.First();
rentalToModify.DueDate = DateTime.Now.AddDays(-3);


Console.WriteLine("\n--- Overdue Rentals ---");
foreach (var o in service.GetOverdueRentals())
    Console.WriteLine($"Overdue: {o.Equipment.Name}");

// Return equipment
service.ReturnEquipment(laptop.Id);

//Final report
Console.WriteLine("--- Final Report ---");
Console.WriteLine(service.GenerateReport());

Console.ReadLine();