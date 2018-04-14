function onRetrieveAll() {
    var uri = 'api/matricresults';

    $(document).ready(function () {

        //tested get
        $.getJSON(uri)
            .done(function (data) {
               
                console.log(data);
            });
     
    });
}

function onPost() {
    var uri = 'api/matricresults';

        //tested post
        $(document).ready(function () {

        let arrResults = [];
        let result = {};
        result["NameOfSchool"] = "Niveks Second School";
        arrResults.push(result);

        let jsonString = JSON.stringify(arrResults);

        $.post(uri, { '': jsonString });
    });
}