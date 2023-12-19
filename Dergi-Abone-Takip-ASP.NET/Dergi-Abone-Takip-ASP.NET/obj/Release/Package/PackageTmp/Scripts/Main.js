//-------------------Kategori İşlemleri-----------------
$(document).on("click", ".ktgEkle", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Ekle',
        html: '<input id="ktgAd" class="swal2-input">',
    });

    if (formValues) {
        var ktgAd = $("#ktgAd").val();

        $.ajax({
            type: 'POST',
            url: '/Kategori/EkleJson',
            data: { "ktgAd": ktgAd },
            dataType: 'json'
        }).done(function (data) {
            var ktgId = data.Result.Id;
            var ktgAd = '<td>' + data.Result.Ad + '</td>';
            var guncelleButon = "<td><button class='guncelle btn btn-custom' value='" + ktgId + "'>Güncelle</button></td>";
            var silButon = "<td><button class='sil btn btn-danger' value='" + ktgId + "'>Sil</button></td>";
            var dergiAdeti = "<td>0</td>";
            $("#example tbody").prepend('<tr>' + ktgAd + dergiAdeti + guncelleButon + silButon + '</tr>');

            Swal.fire({
                icon: 'success',
                title: 'Kategori Eklendi',
                text: 'İşlem başarılı'
            });
        }).fail(function () {
            Swal.fire({
                icon: 'error',
                title: 'Kategori Eklenmedi',
                text: 'Sorun!'
            });
        });
    }
});
$(document).on("click", ".guncelle", async function () {
    var ktgId = $(this).attr('value');
    var ktgAdTd = $(this).closest("tr").find("td:first");
    var ktgAd = ktgAdTd.html();
    const { value: formValues } = await Swal.fire({
        title: 'Kategori Güncelle',
        html: '<input id="ktgAd" value="' + ktgAd + '" class="swal2-input">',
    });
    ktgAd = $("#ktgAd").val();
    $.ajax({
        type: 'POST',
        url: '/Kategori/GuncelleJson',
        data: { "ktgId": ktgId, "ktgAd": ktgAd },
        dataType: 'json'
    }).done(function (data) {
        ktgAdTd.html(ktgAd);
        if (data == "1") {
            Swal.fire({
                icon: 'success',
                title: 'Kategori Güncellendi',
                text: 'İşlem başarılı'
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Kategori Güncellenmedi',
                text: 'Sorun!'
            });
        }
    }).fail(function () {
        Swal.fire({
            icon: 'error',
            title: 'Kategori Güncellenmedi',
            text: 'Sorun!'
        });
    });
});
$(document).on("click", ".sil", async function () {
    var tr = $(this).closest("tr");
    var ktgId = $(this).attr('value');
    $.ajax({
        type: 'POST',
        url: '/Kategori/SilJson',
        data: { "ktgId": ktgId },
        dataType: 'json'
    }).done(function (data) {
        if (data == "1") {
            tr.remove();
            Swal.fire({
                icon: 'success',
                title: 'Kategori Silindi',
                text: 'İşlem başarılı'
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Kategori Silinemedi',
                text: 'Sorun!'
            });
        }
    });
});

//-------------------Kategori İşlemleri Son-----------------

//-------------------Yazar İşlemleri-----------------
$(document).on("click", ".yazarEkle", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Yazar Ekle',
        html: '<input id="yzrAd" class="swal2-input">',
    });

    if (formValues) {
        var yzrAd = $("#yzrAd").val();

        $.ajax({
            type: 'POST',
            url: '/Yazar/EkleJson',
            data: { "yzrAd": yzrAd },
            dataType: 'json'
        }).done(function (data) {
            var yzrId = data.Result.Id;
            var yzrAd = '<td>' + data.Result.Ad + '</td>';
            var guncelleButon = "<td><button class='guncelle btn btn-custom' value='" + yzrId + "'>Güncelle</button></td>";
            var silButon = "<td><button class='sil btn btn-danger' value='" + yzrId + "'>Sil</button></td>";
            var dergiAdeti = "<td>0</td>";
            $("#example tbody").prepend('<tr>' + yzrAd + dergiAdeti + guncelleButon + silButon + '</tr>');

            Swal.fire({
                icon: 'success',
                title: 'Yazar Eklendi',
                text: 'İşlem başarılı'
            });
        }).fail(function () {
            Swal.fire({
                icon: 'error',
                title: 'Yazar Eklenmedi',
                text: 'Sorun!'
            });
        });
    }
});
$(document).on("click", ".yazarSil", async function () {
    var tr = $(this).closest("tr");
    var yazarId = $(this).attr('value');
    $.ajax({
        type: 'POST',
        url: '/Yazar/SilJson',
        data: { "yazarId": yazarId },
        dataType: 'json'
    }).done(function (data) {
        if (data == "1") {
            tr.remove();
            Swal.fire({
                icon: 'success',
                title: 'Yazar Silindi',
                text: 'İşlem başarılı'
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Yazar Silinemedi',
                text: 'Sorun!'
            });
        }
    }).fail(function () {
        Swal.fire({
            icon: 'error',
            title: 'Yazar Silinemedi',
            text: 'Sorun!'
        });
    });

});
$(document).on("click", ".yazarGuncelle", async function () {
    var yzrId = $(this).data('id');
    var yzrAdTd = $(this).closest("tr").find("td:first");
    var yzrAd = yzrAdTd.text();

    const { value: formValues } = await Swal.fire({
        title: 'Yazar Güncelle',
        html: '<input id="yzrAd" value="' + yzrAd + '" class="swal2-input">',
    });

    var yeniYzrAd = $("#yzrAd").val();

    $.ajax({
        type: 'POST',
        url: '/Yazar/GuncelleJson',
        data: { "yzrId": yzrId, "yzrAd": yeniYzrAd },
        dataType: 'json'
    }).done(function (data) {
        if (data == "1") {
            yzrAdTd.text(yeniYzrAd);

            Swal.fire({
                icon: 'success',
                title: 'Yazar Güncellendi',
                text: 'İşlem başarılı'
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Yazar Güncellenmedi',
                text: 'Sorun!'
            });
        }
    }).fail(function () {
        Swal.fire({
            icon: 'error',
            title: 'Yazar Güncellenmedi',
            text: 'Sorun!'
        });
    });
});

//-------------------Yazar İşlemleri Son-----------------

//-------------------Dergi İşlemleri-----------------
$(document).on("click", "#kategoriEkle", async function () {
    var secilenKategoriAd = $("#kategoriler option:selected").text();
    if (secilenKategoriAd != null && secilenKategoriAd != "") {
        var secilenId = $("#kategoriler option:selected").attr("data-id");
        $("#eklenenKategoriler").append('<div id="' + secilenId + '" class="col-md-1 bg-primary kategoriSil" style="margin-right:2px;margin-bottom:2px">' + secilenKategoriAd + '</div>');
        $("#kategoriler option:selected").remove();
    }
});
$(document).on("click", ".kategoriSil", async function () {
    var id = $(this).attr("id");
    var kategoriAd = $(this).html();
    $("#kategoriler").append('<option data-id="' + id + '">' + kategoriAd + '</option>');
    $(this).remove();
});
$(document).on("click", "#dergiKaydet", async function () {
    var degerler = {
        kategoriler: [],
        yazar: $("#yazar option:selected").attr("data-id"),
        dergiAd: $("#dergiAd").val(),
        dergiAdet: $("#dergiAdet").val(),
        siraNo: $("#siraNo").val()
    };

    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });

    $.ajax({
        type: 'POST',
        url: '/Dergi/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    icon: 'success',
                    title: 'Dergi Eklendi',
                    text: 'Başarılı'
                });
            }
            else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    icon: 'error',
                    title: 'Dergi eklenemedi',
                    text: 'Boş alanları lütfen doldurunuz!'
                });
            }
        }
    });
});
$(document).on("click", ".dergiSil", function () {
    Swal.fire({
        title: 'Siliniyor?',
        text: "Dergiyi Silmek istediğinize emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç'

    }).then((result) => {
        if (result.isConfirmed) {
            var dergiId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/Dergi/SilJson',
                data: { "dergiId": dergiId },
                dataType: 'Json',
                success: function (data) {

                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            icon: 'success',
                            title: 'Dergi silindi',
                            text: 'İşlem başarılı'
                        });
                    }
                    else if (data == "dergiBulunamadi") {
                        Swal.fire({
                            icon: 'error',
                            title: 'Dergi silinemedi',
                            text: 'Dergi bulunamadı'
                        });
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Dergi silinemedi',
                            text: 'Sorun oluştu'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Dergi silinemedi',
                        text: 'Bir sorun oluştu'
                    });
                }
            });
        }
    })
});
$(document).on("click", "#dergiGuncelle", async function () {
    var degerler = {
        kategoriler: [],
        yazar: $("#yazar option:selected").attr("data-id"),
        dergiAd: $("#dergiAd").val(),
        dergiAdet: $("#dergiAdet").val(),
        siraNo: $("#siraNo").val(),
        dergiId: $(this).attr("data-id")
    };

    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });

    $.ajax({
        type: 'POST',
        url: '/Dergi/GuncelleJson', // Güncelleme işlemi için uygun URL'yi belirtmelisiniz
        data: JSON.stringify(degerler),
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    icon: 'success',
                    title: 'Dergi güncellendi',
                    text: 'Başarılı'
                });
            }
            else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    icon: 'error',
                    title: 'Dergi güncellenemedi',
                    text: 'Boş alanları lütfen doldurunuz!'
                });
            }
        }
    });
});
$(document).on("click", "#odemeVer", function () {
    var degerler = {
        uyeId: $("#uyeId option:selected").attr("data-id"),
        dergiId: $("#dergiId option:selected").attr("data-id"),
        aboneBitisTarih: $("#aboneBitisTarih").val()
    };

    $.ajax({
        type: 'POST',
        url: '/AlinanDergi/OdemeVerJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    type: 'success',
                    title: 'Ödeme Onaylandı!',
                    text: 'Abone ekleme başarılı.'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Ödeme Onaylanmadı!',
                    text: response.message
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Ödeme Onaylanmadı!',
                text: 'Sorun!'
            });
        }
    });
});
$(document).on("click", "#odemeVerGuncelle", function () {
    var degerler = {
        alinanDergiId: $(this).attr("data-id"),
        uyeId: $("#uyeId").val(),
        dergiId: $("#dergiId").val(),
        aboneBitisTarih: $("#aboneBitisTarih").val()
    };

    $.ajax({
        type: 'POST',
        url: '/AlinanDergi/OdemeDergiGuncelleJson',
        data: JSON.stringify(degerler),
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    type: 'success',
                    title: 'Ödeme Bilgileri Onaylandı!',
                    text: 'Güncelleme başarılı.'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Ödeme Onaylanmadı!',
                    text: response.message
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Ödeme Onaylanmadı!',
                text: 'Bir sorun oluştu!'
            });
        }
    });
});
$(document).on("click", ".odendiOlarakIsaretle", function () {
    Swal.fire({
        title: 'Onaylansın mı?',
        text: "Ödeme Onaylansın mı emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Tamam',
        cancelButtonText: 'Vazgeç'

    }).then((result) => {
        if (result.isConfirmed) {
            var alinanDergiId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/AlinanDergi/OdemeOnayla',
                data: { "alinanDergiId": alinanDergiId },
                dataType: 'Json',
                success: function (data) {
                    if (data == "1") {

                        Swal.fire({
                            icon: 'success',
                            title: 'Ödeme Onaylandı',
                            text: 'İşlem başarılı'
                        });
                    }
                    else if (data == "dergiBulunamadi") {
                        Swal.fire({
                            icon: 'error',
                            title: 'Ödeme Onaylanmadı',
                            text: 'Onaylanmadı'
                        });
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Ödeme Onaylanmadı',
                            text: 'Sorun oluştu'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Dergi silinemedi',
                        text: 'Bir sorun oluştu'
                    });
                }
            });
        }
    })
});





//-------------------Dergi İşlemleri Son-----------------

//-------------------Abone İşlemleri-----------------

$(document).on("click", "#uyeKaydet", function () {
    var degerler = {
        uyeAd: $("#uyeAd").val(),
        uyeSoyad: $("#uyeSoyad").val(),
        uyeAdres: $("#uyeAdres").val(),
        uyeTel: $("#uyeTel").val()
    };

    $.ajax({
        type: 'POST',
        url: '/Uye/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Abone Eklendi',
                    text: 'Abone ekleme başarılı.'
                })
            } else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    icon: 'error',
                    title: 'Abone eklenemedi',
                    text: 'Boş alanları lütfen doldurunuz!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Abone eklenemedi',
                text: 'Sorun!'
            });
        }
    });
});
$(document).on("click", ".uyeSil", function () {
    Swal.fire({
        title: 'Siliniyor?',
        text: "Aboneyi Silmek istediğinize emin misiniz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç'

    }).then((result) => {
        if (result.isConfirmed) {
            var uyeId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/Uye/SilJson',
                data: { "uyeId": uyeId },
                dataType: 'Json',
                success: function (data) {

                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            icon: 'success',
                            title: 'Abone silindi',
                            text: 'İşlem başarılı'
                        });
                    }
                    else if (data == "dergiBulunamadi") {
                        Swal.fire({
                            icon: 'error',
                            title: 'Abone silinemedi',
                            text: 'Abone bulunamadı'
                        });
                    }
                    else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Abone silinemedi',
                            text: 'Sorun oluştu'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Abone silinemedi',
                        text: 'Bir sorun oluştu'
                    });
                }
            });
        }
    })
});
$(document).on("click", "#uyeGuncelle", async function () {
    var degerler = {
        uyeAd: $("#uyeAd").val(),
        uyeSoyad: $("#uyeSoyad").val(),
        uyeAdres: $("#uyeAdres").val(),
        uyeTel: $("#uyeTel").val(),
        uyeId: $(this).data('id')
    };

    $.ajax({
        type: 'POST',
        url: '/Uye/GuncelleJson', // Güncelleme işlemi için uygun URL'yi belirtmelisiniz
        data: JSON.stringify(degerler),
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    icon: 'success',
                    title: 'Abone güncellendi',
                    text: 'Başarılı'
                });
            }
            else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    icon: 'error',
                    title: 'Abone güncellenemedi',
                    text: 'Boş alanları lütfen doldurunuz!'
                });
            }
        }
    });
});

//-------------------Abone İşlemleri Son-----------------

//-------------------ÜyeLik İşlemleri-----------------
$(document).on("click", "#uyelikEkle", function () {
    var uyeId = $("#uyeId").val();
    var mail = $("#mail").val();
    var parola = $("#parola").val();
    var parolaTekrar = $("#parolaTekrar").val();

    $.ajax({
        type: 'POST',
        url: '/Uyelik/EkleJson',
        data: { 'uyeId': uyeId, 'mail': mail, 'parola': parola, 'parolaTekrar': parolaTekrar },
        dataType: 'JSON',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Üye Olundu',
                    text: 'Üye ekleme başarılı.'
                })
            } else if (gelenDeg == "bosOlamaz") {
                Swal.fire({
                    icon: 'error',
                    title: 'Üye Olunamadı',
                    text: 'Boş alanları lütfen doldurunuz!'
                });
            } else if (gelenDeg == "paroloUyusmazligi") {
                Swal.fire({
                    icon: 'error',
                    title: 'Şifre Uyuşmadı',
                    text: 'Şifrenizi Kontrol Ediniz!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Üye Olunamadı',
                text: 'Sorun!'
            });
        }
    });
});

//-------------------ÜyeLik İşlemleri Son-----------------