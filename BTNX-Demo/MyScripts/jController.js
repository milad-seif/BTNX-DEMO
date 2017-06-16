app.controller('questionnaireController', function ($scope, questionnaireService) {
    //The Experience level Object
    $scope.selectedXP = 1;
    $scope.XP = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    //Function to Reset Scope variables
    function initialize() {
        $scope.Keywords = "";
        $scope.Industries = "";
        $scope.Locations = "";
    }

    //Function to Submit the form
    $scope.submitForm = function () {
        var Person = {};
        Person.Experience = $scope.selectedXP;
        Person.Keywords = $scope.Keywords;
        Person.Industries = $scope.Industries;
        Person.Locations = $scope.Locations;

        var promisePost = questionnaireService.postInfo(Person);
        promisePost.then(function (d) {
            $scope.Id = d.data.Id;
        }, function (err) {
            alert("Some Error Occured ");
        });
    };
    //Function to Cancel Form
    $scope.cancelForm = function () {
        $scope.selectedXP = 1;
        initialize();
    };
});