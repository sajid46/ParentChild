function fn_reload() {
    var baseurl = location.href;
    
    $.ajax({
        url: "Jobs/alljobs",
        success: function (result) {
            alert(result.data);
        },
        error: function (result) {
        }
    });
}