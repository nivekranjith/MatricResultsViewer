let self = this;

function readInCsv(file) {

    let fileReader = new FileReader();

    function readSuccess(evt) {

        let data = evt.target.result;

        if (data.startsWith("emis,centre_no,name,wrote_2014,passed_2014,wrote_2015,passed_2015,wrote_2016,passed_2016")) {
            postToDataBase($.csv.toArrays(data));
            console.log($.csv.toArrays(data));

        }
        else {
            alert("incorrect File");
        }

    }

    fileReader.onload = readSuccess;
    fileReader.readAsText(file);

}


function postToDataBase(arrData) {
    let storeKeys = ["Emis", "CenterNo", "NameOfSchool", "Wrote2014", "Passed2014", "Wrote2015", "Passed2015", "Wrote2016", "Passed2016"];

    let listMatricResults = [];

    for (let i = 1 ; i < arrData.length ; i++) {
        let matricResult = {};

        for (let j = 0 ; j < 9 ; j++) {
            if (arrData[i][j] == null ||  arrData[i][j] == "")
                arrData[i][j] = "0";

            matricResult[storeKeys[j]] = arrData[i][j];

            if (j > 2) {
                if (arrData[i][j] == "0")
                    arrData[i][j] = 0;

                arrData[i][j] = parseInt(arrData[i][j]);

                matricResult[storeKeys[j]] = arrData[i][j];


            }

            console.log(arrData[i][j]);
        }

        listMatricResults.push(matricResult);
    }

    console.log(listMatricResults);

    var uri = 'api/matricresults';

    $(document).ready(function () {

        let jsonString = JSON.stringify(listMatricResults);

        $.post(uri, { '': jsonString });
    });
}

