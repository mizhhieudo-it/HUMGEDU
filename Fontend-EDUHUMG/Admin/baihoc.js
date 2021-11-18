$(function(){
    $.ajax({
        type:'GET',
        url:'https://localhost:5001/api/baihoc'
    }).done(function(data,xhr,statuscode){
        console.log(data);
        console.log(xhr);
        console.log(statuscode);
        for(var element = 0 ; element < data.length;element++){
            var showList;
            showList += `<tr>`;
             showList += `<td> ${data[element]['idkhoahoc']} </td>`;
             showList += `<td> ${data[element]['idbaihoc']} </td>`;
             showList += `<td> ${data[element]['linkbaihoc']} </td>`;
             showList += `<td> ${data[element]['linkvideobaihoc']} </td>`;
            //  showList += `<td> ${data[element]['linkbaihoc']} </td>`;
            //  showList += `<td> ${data[element]['thoigiantaobaihoc']} </td>`;
            //  showList += `<td> ${data[element]['thoigiansuabaihoc']} </td>`;
            //  showList += `<td> ${data[element]['nguoitaobaihoc']} </td>`;
            //  showList += `<td> ${data[element]['nguoisuabaihoc']} </td>`;
             showList += `<td><button class="btn btn-success" data-toggle="modal" data-target="#exampleModal" onclick="suabaihoc(${data[element]['idbaihoc']})">Sửa</button>
             <button class="btn btn-danger" onclick="xoabh(${data[element]['idbaihoc']})">Xóa</button>
             <button class="btn btn-warning" onclick="chitiet(${data[element]['idbaihoc']})">Xem Chi Tiết</button>

             </td>` 
             showList += `</tr>`;
             
    
        }
        $('#showdata').html(showList);
    })
    

});
function SentData(urlsent,methodsent,id){
    var dataf = {
        "idkhoahoc":$("#tendm").val(),
        "tieudebaihoc":$("#linkdm").val(),
        "motabaihoc":$("#tendm").val(),
        "linkvideobaihoc":$("#linkdm").val(),
        "linkbaihoc":$("#tendm").val(),
        "thoigiantaobaihoc":$("#linkdm").val(),
        "thoigiansuabaihoc":$("#tendm").val(),
        "nguoitaobaihoc":$("#linkdm").val(),
        "nguoisuabaihoc":$("#tendm").val(),
        "linkdanhmuc":$("#linkdm").val(),
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
        location.reload();
        console.log(dataf)
        console.log(id);
    }).fail(function(){
        alert("Thao tác thất bại");
        console.log(dataf)
        console.log(id);
    })

}
function themsach() {
    SentData("https://localhost:5001/api/baihoc", "POST", null);
  //  window.location="sach.html";
     
  }
  function xoabh(idbh) {
    $(function () {
      $.ajax({
        type: "DELETE",
        url: `https://localhost:5001/api/baihoc/${idbh}`,
      })
        .done(function () {
          alert("Xóa dữ liệu thành công");
          location.reload();
        })
        .fail(function () {
          alert("Xóa dữ liệu thất bại");
        });
    });
  }
  function suabaihoc(idbh){
    window.location="updatebaihoc.html?handle=update&id="+idbh ; 

  }
  function chitiet(idbh){
    window.location="xemchitiet.html?handle=view&id="+idbh ;
  }