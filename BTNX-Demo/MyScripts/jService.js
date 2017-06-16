app.service("questionnaireService", function ($http) {

    this.getInfo = function (id) {
        var req = $http.get('/api/QuestionnaireAPI/' + id);
        return req;
    };

    this.getAppInfo = function () {
        var req = $http.get('/api/QuestionnaireAPI');
        return req;
    }

    this.postInfo = function (personInfo) {
        var req = $http.post('/api/QuestionnaireAPI', personInfo);
        return req;
    };

});