var mbsa = angular.module("mbsa", []);
mbsa.controller("mbsacontroller", function ($scope) {
    $scope.CurrentPage = 1;
    $scope.PageSize = 10;
    $scope.TotalCount = 0;
    $scope.Pages = [];
    $scope.GetProjects = function () {
        Post("/Home/GetProjects?PageSize=" + $scope.PageSize + "&PageNumber=" + $scope.CurrentPage, null, null, function (result) {
            $scope.Projects = JSON.parse(result.responseText);
            $scope.$digest();
        });
    };
    $scope.Previous = function () {
        if ($scope.CurrentPage > 1) {
            $scope.CurrentPage = $scope.CurrentPage - 1;
        }
        $scope.GetProjects();
    }
    $scope.Next = function () {
        $scope.CurrentPage = $scope.CurrentPage + 1;
        $scope.GetProjects();
    }
    $scope.GetTotalCount = function () {
        Post("/Home/GetTotalRecordCount", null, null, function (result) {
            $scope.TotalCount = parseInt(result.responseText);
            var numberOfPages = ($scope.TotalCount / $scope.PageSize);
            for (index = 1; index <= numberOfPages; index++) {
                $scope.Pages.push(index);
            }
            $scope.$digest();
        });
    };
    $scope.SetPageNumber = function (pageNumber) {
        $scope.CurrentPage = pageNumber;
        $scope.GetProjects();
    }
    $scope.GetProjects();
    $scope.GetTotalCount();
})