function Post(url, data, OnError, OnComplete) {

    var dataJson = JSON.stringify(data);
    $.ajax({
        url: url,
        type: 'POST',
        data: dataJson,
        dataType: 'text',
        contentType: 'application/json; charset=utf-8',
        error: function (jqXHR, testStatus, errorThrown) {
            if (OnError) { OnError(errorThrown); }
        },
        complete: function (result) {
            OnComplete(result);
        },

    });
}