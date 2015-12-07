var app = angular.module('appTeste', ['ui.mask', 'ui.bootstrap']);
app.controller('ctrlFormularioTeste', function ($http, $scope, $uibModal, $log, MessageService) {

    $scope.message = '';
    $scope.user = {};

    $scope.salva = function () {
        $http.post('/FormularioTeste/Salva', $scope.user).then(function (resp) {
            debugger;
            $scope.message = resp.data;
            MessageService.setMessage($scope.message);
            if (resp.data.TipoDeMensagem.Tipo == 5) {
                $scope.ObtemTodos();
                $scope.limpa();             
            }

            $scope.openModal();
        });
    }
}).factory('MessageService', function () {
    var message = '';
    return {
        setMessage: function (msg) {
            message = msg;
        },
        getMessage: function () {
            return message;
        }
    };
})