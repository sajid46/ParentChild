

function fn_displaytable(o) {
    if (o.innerText == 'MVC Table') {
        $('#div-ajaxtable').hide();
        $('#div-mvctable').show();
    }
    else {
        $('#div-ajaxtable').show();
        $('#div-mvctable').hide();
        fn_fetch();
    }
}

function fn_fetch() {
    $.ajax({
        url: 'Jobs/JobsPartial',
        dataType: 'json',
        success: function (data, status, xhr)
        {
            vm.jobs = data;
        },
        error: function (data, status, xhr)
        {
        }
    });
}