function Reduce(key, arr_values) {
    /* 
    var reduced = initialze; //a document
    var temp;
    for(var i in arr_values) {
    temp = arr_values[i];
    reduced = Apply-Reduce-Logic-Using(temp, reduced);
    }
    return {reduced}
    */

    var result = { count: 0, double1: 0 };

    arr_values.forEach(function (value) {
        result.count += value.count;
        result.double1 += value.double1;
    });

    return result;

    //return arr_values[0];
}