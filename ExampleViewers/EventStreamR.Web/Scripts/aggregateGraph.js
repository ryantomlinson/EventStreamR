var graphInitialised = false;
var graph;

function setupGraph(dataValues, keys) {
    graph = Morris.Line({
        element: 'graph',
        data: dataValues,
        xkey: 'x',
        ykeys: keys,
        labels: keys,
        parseTime: false,
        hideHover: true
    });
}

function graphPulse(observableArray) {
    var sliceSize = 50;
    var numberOfNotifications = observableArray().length;
    if (numberOfNotifications < sliceSize) {
        sliceSize = numberOfNotifications;
    }

    var graphItems = observableArray.slice(numberOfNotifications - sliceSize, numberOfNotifications);
    //need at least 2 datapoints to start with
    if (graphItems.length > 1) {
        var ret = [];
        for (var i in graphItems) {
            if (i > 0) {
                var dataPoint = [];
                dataPoint.x = i;
                for (var e in graphItems[i].Items) {
                    dataPoint[graphItems[i].Items[e].Key] = graphItems[i].Items[e].Count - graphItems[i - 1].Items[e].Count;
                }
                ret.push(dataPoint);
            }
        }

        if (!graphInitialised) {
            //work out the possible keys
            var keys = new Array()
            for (var e in graphItems[0].Items) {
                keys.push(graphItems[0].Items[e].Key);
            }
            setupGraph(ret, keys);
            graphInitialised = true;
        }
        else {
            graph.setData(ret);
        }
    }
}