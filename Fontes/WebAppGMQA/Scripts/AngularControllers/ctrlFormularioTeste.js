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
                    $interval.cancel(timerPromise);
                    if (document.origin != undefined)
                        window.location.assign(document.origin + "/Home");
                    else
                        window.location.assign("/Home");
                    break;
            }
        };
    
    $scope.executa = function () {
        timerPromise = $interval($scope.tickInterval, 1000);
    };
}])