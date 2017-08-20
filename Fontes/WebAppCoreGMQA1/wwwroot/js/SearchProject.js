function SearchProject(url) {
    $.ajax({       
        url: url,
        type: 'post',
        dataType: 'html',
        data: {
            filtro: $("#filtro").val()
        },
        success: function (data) {
            $('#example').DataTable();
        }
    });
}