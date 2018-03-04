$(document).ready(function () {
   // GetCourses();
    AddNewCourse();
    AddEmployee();
});
var baseUrl = "http://localhost:52274/api/TrainingManagement/";
function GetCourses() {
    //var apiUrl = baseUrl + "GetTrainingCourses";
    //$.ajax({
    //    type: "Get",
    //    url: "http://localhost:52297/api/EmployeesApi",
    //   // contentType: "application/json; charset=utf-8",
    //    // dataType: "jsonp",
    //    // asyc:false,
    //    cache:false,
    //    succuss: function (result) {
    //        alert(JSON.stingify(result));
    //        console.log(JSON.stingify(result));
    //    },
    //    failuer: function(reason){
    //        alert(reason);
    //    },
    //    error: function (error) {
    //        alert("error");
    //    }
    //}).done(function(result)
    //{
    //    alert("done");}).fail(function (err) { alert("fail")});
    var url = "http://localhost:52274/api/TrainingManagement/GetTrainingCourses";
    $.ajax({
        url: url,//'http://localhost:52297/api/EmployeesApi',
        type: 'GET',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus, xhr) {
            console.log(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Database');

        }
    });
}

function AddNewCourse() {
    var apiUrl = baseUrl + "AddCourse";
    var data = {
        CourseTitle: "Web api",
        CourseDescription: "This is advance course",
        CourseDurationHrs: "10",
        CourseFee: 8000
    };
    $.ajax({
        type: "post",
        url: apiUrl, dataType: "json",
       // contentType: "application/json; charset=utf-8",
        data: data,
        succuss: function (result) { 
            console.log('suc');
        },
        error: function (error) {
            console.log("error");
        }
    });
}

function AddEmployee() {
    var apiUrl = "http://localhost:52297/api/EmployeesApi";
    var data = {
        Name: "pranali",
        Dob: new  Date("17/11/1990"),
        Salary:1000
    };
    $.ajax({
        type: "post",
        url: apiUrl,
        dataType: "json",
       // contentType: "application/json; charset=utf-8",
        data: data,
        succuss: function (result) {
            console.log('suc');
        },
        error: function (error) {
            console.log("error");
        }
    });
}