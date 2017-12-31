function KategoriEkle() {//Sol tarafta kategoiden sonra yazılan alanlar kategori sınıfındakiler ile aynı,sağ taraftaki idler önyüzdeki ile aynı olmalıdır.
    Kategori = new Object();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    Kategori.URL = $("#katURL").val();
    Kategori.AktifMi = $("#katAktif").is(":checked");
    Kategori.ParentID = $("#ParentID").val();

    $.ajax({
        url: "/Kategori/Create",
        data: Kategori,
        type: "Post",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                    //window.location.href = "Index";
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //window.location.href = "Index";
                });
            }
        }
    })
}

function KategoriSil() {

    var gelenID = $("#katDelete").attr("data-id");

    $.ajax({

        url: "/Kategori/Delete/" + gelenID,
        type: "POST",
        dataType: "json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {
                    //Geri Dönüş olumsuz olduğunda birşey yapılmasını istersek buraya yazılır
                });
            }
        }
    })
}

function KategoriDüzenle() {//Sol tarafta kategoiden sonra yazılan alanlar kategori sınıfındakiler ile aynı,sağ taraftaki idler önyüzdeki ile aynı olmalıdır.
    Kategori = new Object();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    Kategori.URL = $("#katURL").val();
    Kategori.AktifMi = $("#katAktif").is(":checked");
    Kategori.ParentID = $("#ParentID").val();
    Kategori.ID = $("#ID").val();

    $.ajax({
        url: "/Kategori/Edit",
        data: Kategori,
        type: "Post",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                });
            }
            else {
                bootbox.alert(response.Message, function () {

                });
            }
        }
    })
}