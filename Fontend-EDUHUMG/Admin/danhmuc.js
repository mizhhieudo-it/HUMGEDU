$(function(){
    $.ajax({
        type:'GET',
        url:'https://localhost:5001/api/danhmuc'
    }).done(function(data){
        console.log(data);
        for(var element = 0 ; element < data.length;element++){
            var showList;
            showList += `<tr>`;
             showList += `<td> ${data[element]['tendanhmuc']} </td>`;
             showList += `<td> ${data[element]['linkdanhmuc']} </td>`;
             showList += `<td><button class="btn btn-success" data-toggle="modal" data-target="#exampleModal" onclick="suadanhmuc(${data[element]['iddanhmuc']})">Sửa</button>
             <button class="btn btn-danger" onclick="xoadm(${data[element]['iddanhmuc']})">Xóa</button>
             <button class="btn btn-warning" onclick="xoadm(${data[element]['iddanhmuc']})">Xem chi tiết</button>
             </td>` 
             showList += `</tr>`;
             
    
        }
        $('#showData').html(showList);
    })
    

});
function SentData(urlsent,methodsent,id){
    var dataf = {
        "tendanhmuc":$("#tendm").val(),
        "linkdanhmuc":$("#linkdm").val(),



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
function showbtnsave(){
    document.getElementById("btnthem").style.display = "block";
    document.getElementById("btnsua").style.display = "none";

}
