function SentData(urlsent,methodsent,id){
    var dataf = {
        "idkhoahoc":parseInt($('#idkhoahoc').find(":selected").attr("value")),
        "tieudebaihoc":$("#tieudebaihoc").val(),
        "motabaihoc":CKEDITOR.instances['ContentLesson'].getData(),
        "linkvideobaihoc":$("#linkvideo").val(),
        "linkbaihoc":$("#linkbaihoc").val(),
        "thoigiantaobaihoc":$("#timetao").val(),
        // "thoigiansuabaihoc":$("#timesua").val(),
        "nguoitaobaihoc":$("#nguoitao").val(),
        // "nguoisuabaihoc":$("#nguoisua").val(),
        "trangthaibaihoc":Boolean($("input[type='radio']:checked").val()),
    };
    if(id !== null){
        urlsent =`${urlsent}/${id}` ;
        dataf = {
            "manv":$("#saveid").val(),
            "tennv":$("#tennhanvien").val(),
            "diachi":$("#dichinhanvien").val(),
            "dienthoai":$("#sdtnhanvien").val(),
            "phai":$("input[type='radio']:checked").val()
        };
    }
    $.ajax({
        
        url:urlsent,
        type:methodsent,
        data:dataf,
        contentType:'application/json',
        data:JSON.stringify(dataf),
    }).done(function(data){
        console.log(data);
        alert("Thao tác thành công");
        window.location="index.html";

    }).fail(function(){
        alert("Thao tác thất bại");
        console.log(dataf)
        console.log(id);
    })

}
function thembaihoc() {
    SentData("https://localhost:5001/api/baihoc", "POST", null);
     
  }