
var allMatricResultsData = [];

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

function createLineChart(title , axisX , axisY , data , divId)
{
    var options = {

        animationEnabled: true,
        theme: "light2",
        title: {
            text: title
        },
        axisX: axisX,
        axisY: axisY,
        toolTip: {
            shared: true
        },
        legend: {
            cursor: "pointer",
            verticalAlign: "bottom",
            horizontalAlign: "left",
            dockInsidePlotArea: true,
        },
        data: data
    }

    console.log(options);

     $("#" + divId).CanvasJSChart(options);
    

}

function createMultiAxisLineChart(title, axisX, axisY,axisY2, data, divId) {
    var options = {

        animationEnabled: true,
        theme: "light2",
        title: {
            text: title
        },
        axisX: axisX,
        axisY: axisY,
        axisY2: axisY2,
        toolTip: {
            shared: true
        },
        legend: {
            cursor: "pointer",
            verticalAlign: "bottom",
            horizontalAlign: "left",
            dockInsidePlotArea: true,
        },
        data: data
    }

    console.log(options);

    $("#" + divId).CanvasJSChart(options);


}

function createMultiBarChart(title, axisY,  data, divId) {
    var options = {

        animationEnabled: true,
        theme: "light2",
        title: {
            text: title
        },
        axisY: axisY,
        toolTip: {
            shared: true
        },
        legend: {
            cursor: "pointer",
        },
     
        data: data
    }


    $("#" + divId).CanvasJSChart(options);


}

function generateOverAllPassRate() {
    let title = "Overall Pass Rate (2014 - 2016)";

    let axisY = {
        title: "Pass Rate (%)",
        maximum: 100

    };

    let data = [];
    let objCalculation = {};
    objCalculation["2014"] = { Passed: 0, Wrote: 0 };
    objCalculation["2015"] = { Passed: 0, Wrote: 0 };
    objCalculation["2016"] = { Passed: 0, Wrote: 0 };



    for (let i = 0 ; i < allMatricResultsData.length ; i++) {
        let result = allMatricResultsData[i];
        objCalculation["2014"]["Passed"] += result["Passed2014"];
        objCalculation["2014"]["Wrote"] += result["Wrote2014"];
        objCalculation["2015"]["Passed"] += result["Passed2015"];;
        objCalculation["2015"]["Wrote"] += result["Wrote2015"];;
        objCalculation["2016"]["Passed"] += result["Passed2016"];
        objCalculation["2016"]["Wrote"] += result["Wrote2016"];;


    }

    let dataLineWrote = {

        type: "column",
        showInLegend: true,
        markerType: "square",
        color: "green",
        dataPoints: [],
        name: "Student Pass Rate per Year",


    };


    for (let key in objCalculation) {
        let instance = objCalculation[key];

        dataLineWrote.dataPoints.push({ label: key, y: (instance["Passed"] / instance["Wrote"]) * 100 });

    }

    data.push(dataLineWrote);

    createMultiBarChart(title, axisY, data, "overAllPassRate")
}

function generateOverAllChart() {
    let title = "Overall Results (2014 - 2016)";
  
    let axisY = {
        title: "Number of students",
    };

    let axisX = {
        intervalType: "year",
        interval: 1,

    }

    let data = [];
    let objCalculation = {};
    objCalculation["2014"] = { Passed: 0, Wrote: 0 };
    objCalculation["2015"] = { Passed: 0, Wrote: 0 };
    objCalculation["2016"] = { Passed: 0, Wrote: 0 };
   
   

    for(let i = 0 ; i < allMatricResultsData.length ; i++ )
    {
        let result = allMatricResultsData[i];
        objCalculation["2014"]["Passed"] += result["Passed2014"];
        objCalculation["2014"]["Wrote"] += result["Wrote2014"];
        objCalculation["2015"]["Passed"] += result["Passed2015"];;
        objCalculation["2015"]["Wrote"] += result["Wrote2015"];;
        objCalculation["2016"]["Passed"] += result["Passed2016"];
        objCalculation["2016"]["Wrote"] += result["Wrote2016"];;
        

    }

    let dataLineWrote = {

        type: "line",
        showInLegend: true,
        name: "# Students that wrote matric",
        markerType: "square",
        color: "blue",
        dataPoints: []

    };

    let dataLinePassed = {

        type: "line",
        showInLegend: true,
        name: "# Students that passed matric",
        dataPoints:[]
    };

    for(let key in objCalculation)
    {
        let instance = objCalculation[key];

        dataLineWrote.dataPoints.push({ x:  new Date(parseInt(key),01,01) , y: instance["Wrote"] });
        dataLinePassed.dataPoints.push({ x: new Date(parseInt(key),01,01) , y: instance["Passed"] });

    }

    data.push(dataLineWrote);
    data.push(dataLinePassed);

    createLineChart(title,axisX, axisY, data, "overAllBarChart")

}

function generateTopBestPassRate2016(){
    let title = "Top 5 Best Pass Rates";
  
    let axisY = {
        title: "Pass Rate(%)",
        maximum : 100
    };

    let axisX = {    

    }

    let data = [];
    let objCalculation = [];

    let minBestIndex = 0 ;
   
    let bestNames = [];
    let bestValues = [];

    for(let i = 0 ; i < allMatricResultsData.length ; i++ )
    {
        if(bestNames.length < 5)
        {
            bestNames.push(allMatricResultsData[i]["NameOfSchool"]);
            bestValues.push(allMatricResultsData[i]["PassRate2016"]);

        }

        if (allMatricResultsData[i]["PassRate2016"] > bestValues[minBestIndex]) {

            bestNames[minBestIndex] = allMatricResultsData[i]["NameOfSchool"];
            bestValues[minBestIndex] = allMatricResultsData[i]["PassRate2016"];

            minBestIndex = 0;
            for(let j = 0 ; j < bestValues.length ; j++)
            {
                if(bestValues[j] < bestValues[minBestIndex])
                {
                    minBestIndex = j;
                }
            }
        }
    }



    let dataLine = {

        type: "column",
        showInLegend: true,
        name: "School Name",
        markerType: "square",
        color: "blue",
        dataPoints: []

    };

    for (let i = 0 ; i < bestNames.length ; i++)
    {
        dataLine.dataPoints.push({ label: bestNames[i], y: bestValues[i] });

    }

    data.push(dataLine);

    createLineChart(title, axisX, axisY, data, "top10Best2016")
}

function generateTopWorstPassRate2016() {
    let title = "Top 5 Lowest Pass Rates";

    let axisY = {
        title: "Pass Rate(%)",
        maximum: 100
    };

    let axisX = {

    }

    let data = [];

    let minBestIndex = 0;

    let bestNames = [];
    let bestValues = [];

    for (let i = 0 ; i < allMatricResultsData.length ; i++) {
        if (bestNames.length < 5) {
            bestNames.push(allMatricResultsData[i]["NameOfSchool"]);
            bestValues.push(allMatricResultsData[i]["PassRate2016"]);

        }

        if (allMatricResultsData[i]["PassRate2016"] < bestValues[minBestIndex]) {

            bestNames[minBestIndex] = allMatricResultsData[i]["NameOfSchool"];
            bestValues[minBestIndex] = allMatricResultsData[i]["PassRate2016"];

            minBestIndex = 0;
            for (let j = 0 ; j < bestValues.length ; j++) {
                if (bestValues[j] > bestValues[minBestIndex]) {
                    minBestIndex = j;
                }
            }
        }
    }



    let dataLine = {

        type: "column",
        showInLegend: true,
        name: "School Name",
        markerType: "square",
        color: "blue",
        dataPoints: []

    };

    for (let i = 0 ; i < bestNames.length ; i++) {
        dataLine.dataPoints.push({ label: bestNames[i], y: bestValues[i] });

    }

    data.push(dataLine);

    createLineChart(title, axisX, axisY, data, "top10Worst2016")
}

function generateHighestStudentNumberWithPassRate()
{
    let title = "Top 5 schools with highest number of Students vs Pass Rate";

    let axisY = {
        title: "Number of students",
    };

    let axisY2 = {
        title: "Pass Rate(%)",
        maximum: 100
    };

    let axisX = {
        title: "",
        tickLength: 0,
        margin: 0,
        lineThickness: 0,
        valueFormatString: " "

    }

    let data = [];
    let minBestIndex = 0;

    let schoolStudentNumber = [];
    let schoolPassRates = [];
    let schoolName = [];

    for (let i = 0 ; i < allMatricResultsData.length ; i++) {
        if (schoolStudentNumber.length < 5) {
            schoolStudentNumber.push(allMatricResultsData[i]["Wrote2016"]);
            schoolPassRates.push(allMatricResultsData[i]["PassRate2016"]);
            schoolName.push(allMatricResultsData[i]["NameOfSchool"]);

        }

        if (allMatricResultsData[i]["Wrote2016"] > schoolStudentNumber[minBestIndex]) {

            schoolStudentNumber[minBestIndex] = allMatricResultsData[i]["Wrote2016"];
            schoolPassRates[minBestIndex] = allMatricResultsData[i]["PassRate2016"];
            schoolName.push(allMatricResultsData[i]["NameOfSchool"]);


            minBestIndex = 0;
            for (let j = 0 ; j < schoolStudentNumber.length ; j++) {
                if (schoolStudentNumber[j] > schoolStudentNumber[minBestIndex]) {
                    minBestIndex = j;
                }
            }
        }
    }

    let dataLinePassRate = {

        type: "line",
        showInLegend: true,
        name: "# Pass Rate",
        axisYType: "secondary",
        markerType: "square",
        color: "blue",
        dataPoints: []

    };

    let dataLineNumberStudents = {

        type: "column",
        showInLegend: true,
        name: "Number of students",
        dataPoints: []
    };

    for (let i = 0 ; i < schoolStudentNumber.length ; i++)
    {
        dataLineNumberStudents.dataPoints.push({ x: i, y: schoolStudentNumber[i] });
        dataLinePassRate.dataPoints.push({x: i , y: schoolPassRates[i] });

    }

    data.push(dataLineNumberStudents);
    data.push(dataLinePassRate);

    createMultiAxisLineChart(title, axisX, axisY,axisY2, data, "studentNumberPassRate" );

}

function onLoadPageLoad() {

    var uri = 'api/matricresults';

    $(document).ready(function () {
        $.getJSON(uri)
            .done(function (data) {

                allMatricResultsData = data;
                generateOverAllChart();
                generateOverAllPassRate();
                generateTopBestPassRate2016();
                generateTopWorstPassRate2016();
                generateHighestStudentNumberWithPassRate();
            });

    });

}