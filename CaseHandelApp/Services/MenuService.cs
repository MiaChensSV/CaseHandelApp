using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseHandelApp.Models.Form;

namespace CaseHandelApp.Services
{
    internal class MenuService
    {
        private readonly CaseService _caseService = new CaseService();
        private readonly UserService _userService = new UserService();
        public async Task MainMenu()
        {

            Console.Clear();
            Console.WriteLine("Welcome. This is YAKI Insurance.");
            Console.WriteLine("What can I help you with?\n\n");
            Console.WriteLine("1, Register as a user");
            Console.WriteLine("2, Report an issue");
            Console.WriteLine("3, Check the status of reported issue");
            Console.WriteLine("4, Get all issues(!!Only for employee)");
            Console.WriteLine("5, Add comments to existing issue(!!Only for employee)");
            Console.WriteLine("6, Change Status of existing issue(!!Only for employee)\n");

            Console.WriteLine("Please enter your choice\n");
            Console.WriteLine("If you want to quit, please enter Q\n");

            var choice = Console.ReadLine()!.ToLower().Trim();

            switch (choice)
            {
                case "1":
                    await CreateUser();
                    break;
                case "2":
                    await CreateReport();
                    break;
                case "3":
                    await GetSpecific();
                    break;
                case "4":
                    await GetAll();
                    break;
                case "5":
                    await CreateComment();
                    break;
                case "6":
                    await Update();
                    break;
                case "q":
                    await ExitProgram();
                    break;
                default:
                    Console.WriteLine("Invaild input");
                    Thread.Sleep(2000);
                    await MainMenu();
                    break;
            }
            Console.ReadKey();
        }

        private async Task CreateUser()
        {
            var _form = new UserRegistrationForm();
            Console.Clear();
            Console.WriteLine("***********Create new user***********");
            Console.WriteLine("***Please type in your FirstName***");
            string? _input=Console.ReadLine()!.Trim().ToLower();
            if (!string.IsNullOrEmpty(_input))
            {
                _form.FirstName = _input;
            }

            else Console.WriteLine("***Invailid input***");

            Console.WriteLine("***Please type in your LastName***");
            _input = Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.LastName = _input;
            }
            else Console.WriteLine("***Invailid input***");

            Console.WriteLine("***Are you an employee? If yes type yes***");
            _input = Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                if (_input.ToLower().Trim() == "yes")
                    _form.UserTypeName = "Employee";
                else _form.UserTypeName = "Customer";
            }
            else Console.WriteLine("***Invailid input***");

            Console.WriteLine("***Please type in your Email***");
            _input = Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.Email = _input;
            }
            else Console.WriteLine("***Invailid input***");
            Console.WriteLine("***Please type in your PhoneNumber***");
            _input= Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.PhoneNumber = _input;
            }
            else Console.WriteLine("***Invailid input***");
            Console.WriteLine("***Please type in your StreetName***");
            _input= Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.StreetName = _input;
            }
            else Console.WriteLine("***Invailid input***");
            Console.WriteLine("***Please type in your PostalCode***");
            _input= Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.PostalCode = _input;
            }
            else Console.WriteLine("***Invailid input***");
            Console.WriteLine("***Please type in your City***");
            _input= Console.ReadLine()!.Trim().ToLower(); 
            if (!string.IsNullOrEmpty(_input))
            {
                _form.City = _input;
            }
            else Console.WriteLine("***Invailid input***");

            var result = await _userService.CreateUser(_form);
            if (result == null) { Console.WriteLine($"***{_form.FirstName} already exist***"); }
            else { Console.WriteLine($"***User {_form.FirstName} has created***"); }
        }

        private async Task Update()
        {

        }

        private async Task CreateComment()
        {
        }

        private async Task GetAll()
        {
            Console.Clear();

            foreach (var cases in await _caseService.GetAllAsync())
            {
                Console.WriteLine(
                    $"Case Id is {cases.Id}\n Case is created at {cases.Created} by user {cases.User.FirstName} {cases.User.LastName}\n " +
                    $"The status is {cases.Status.StatusName}.\n Case title is {cases.Title}\n Case Description is {cases.Description}\n");
            }
        }

        private async Task GetSpecific()
        {
            Console.Clear();
            Console.WriteLine("Please enter the CaseNumber you are looking for");
            var caseId = Console.ReadLine()!.Trim();
            if (!string.IsNullOrEmpty(caseId))
            {
                if (IsGuid(caseId))
                {
                    var aimedCase = await _caseService.GetSpecificAsync(x => x.Id == Guid.Parse(caseId));
                    if (aimedCase != null)
                    {

                        Console.WriteLine($"Case Id is {aimedCase.Id}\n Case is created at {aimedCase.Created} by user {aimedCase.User.FirstName} {aimedCase.User.LastName}\n " +
                        $"The status is {aimedCase.Status.StatusName}.\n Case title is {aimedCase.Title}\n Case Description is {aimedCase.Description}\n");
                        if (aimedCase.Comments.Count > 0)
                        {
                            foreach (var comment in aimedCase.Comments)
                            {
                                Console.WriteLine($"Case comments are {comment}");
                            }
                        }
                        else Console.WriteLine($"There is no comments related to this case {aimedCase.Title}");
                    }
                    else Console.WriteLine($"There is no case related to this CaseNumber{caseId}");
                }
                else Console.WriteLine("You did not type in right case number.\nIt should be in Format FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
            }
        }

        private async Task CreateReport()
        {
            var _form = new CaseRegistrationForm();
            Console.Clear();
            Console.WriteLine("***Please verify yourself by enter your email***");
            string? _input = Console.ReadLine()!.Trim().ToLower();
            var userEmail=_userService.GetUser(_input);
            if (userEmail!=null)
            {
                Console.WriteLine("***Please type in the report name***");
                _input = Console.ReadLine()!.Trim().ToLower();
                if (!string.IsNullOrEmpty(_input))
                {
                    _form.Title= _input;
                }else Console.WriteLine("***The title is empty***");

                Console.WriteLine("***Please describe the issue in detail***");
                _input = Console.ReadLine()!.Trim().ToLower();
                if (!string.IsNullOrEmpty(_input))
                {
                    _form.Description = _input;
                }
                else Console.WriteLine("***The description is empty***");

                var result = await _caseService.CreateAsync(_form);
                Console.WriteLine(result);
                Console.ReadKey();
                if (result == null) { Console.WriteLine($"***{_form.Title} already exist***"); }
                else { Console.WriteLine($"***User {_form.Title} has created***"); }
            }
            else
            {
                Console.WriteLine("***You are not registed in our system***");
                Console.WriteLine("***Please register first***");
                Console.ReadKey();
                Console.Clear();
                await MainMenu();
            }
        }
        public async Task ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("You have exit program");
            Console.WriteLine("Press enter to main meny");
            Console.ReadLine();
            await MainMenu();
        }
        private static bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
    }
}
