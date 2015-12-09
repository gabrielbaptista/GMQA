var app = angular.module('appTeste', []);


app.controller('ctrlFormularioTeste', ['$http', '$scope', '$interval', function ($http, $scope, $interval) {
    var timerPromise;
    $scope.status = "Aguardando ação..."
    

    $scope.tickInterval = function() {
            switch ($scope.status)
            {
                case "Aguardando ação...":
                    $scope.status = "Agindo..."
                    break;
                case "Agindo...":
                    $scope.status = "Concluído!"
                    break;
                case "Concluído!":
                    $scope.status = "Aguardando ação..."
                    $interval.cancel(timerPromise);
                    break;
            }
        };
    
    $scope.executa = function () {
        timerPromise = $interval($scope.tickInterval, 1000);
    };
}])