var Url = window.location.href;
var GetID = Url.split("?");
var id = GetID[1].split("?");
var x = id[0].split("=");
var realid = x[2];
$(function () {
  $.ajax({
    type: "GET",
    url: `https://localhost:5001/api/Baihoc/SearchByid?id=${realid}`,
  }).done(function (data) {
    console.log(data);

    $("#idbaihoc").val(data[0].less["idbaihoc"]);
    var selecttheloai = document.getElementById("idkhoahoc");
    selecttheloai.innerHTML = `<option value="${data[0].less["idkhoahoc"]}" selected >${data[0].titlecourse} </option>`;
    $("#tieudebaihoc").val(data[0].less["tieudebaihoc"]);
    $("textarea#ContentLesson").val(data[0].less["motabaihoc"]);
    $("#linkvideo").val(data[0].less["linkvideobaihoc"]);
    $("#linkbaihoc").val(data[0].less["linkbaihoc"]);
    $("#nguoitao").val(data[0].less["nguoitaobaihoc"]);
    var time1 = (data[0].less["thoigiantaobaihoc"].split("T"));
    $("#timetao").val(time1[0]) 

    var rel = null;
    if (data[0].less["trangthaibaihoc"] == true) {
      rel = 1;
    } else {
      rel = 0;
    }

    $("input[name=status][value=" + rel + "]").prop("checked", true);
  });
});
function SentData(urlsent, methodsent, id) {
  var dataf = {
    idbaihoc:  parseInt($("#idbaihoc").val()),
    idkhoahoc: parseInt($("#idkhoahoc").find(":selected").attr("value")),
    tieudebaihoc: $("#tieudebaihoc").val(),
    motabaihoc: CKEDITOR.instances["ContentLesson"].getData(),
    linkvideobaihoc: $("#linkvideo").val(),
    linkbaihoc: $("#linkbaihoc").val(),
    //thoigiantaobaihoc: $("#timetao").val(),
    thoigiansuabaihoc:$("#timesua").val(),
    //nguoitaobaihoc: $("#nguoitao").val(),
    nguoisuabaihoc:$("#nguoisua").val(),
    trangthaibaihoc: Boolean($("input[type='radio']:checked").val()),
  };
  if (id !== null) {
    urlsent = `${urlsent}/${id}`;
    dataf = {
      idbaihoc:  parseInt($("#idbaihoc").val()),
      idkhoahoc: parseInt($("#idkhoahoc").find(":selected").attr("value")),
      tieudebaihoc: $("#tieudebaihoc").val(),
      motabaihoc: CKEDITOR.instances["ContentLesson"].getData(),
      linkvideobaihoc: $("#linkvideo").val(),
      linkbaihoc: $("#linkbaihoc").val(),
      thoigiantaobaihoc: $("#timetao").val(),
      thoigiansuabaihoc:($("#timesua").val()),
      nguoitaobaihoc: $("#nguoitao").val(),
      nguoisuabaihoc:$("#nguoisua").val(),
      trangthaibaihoc: Boolean($("input[type='radio']:checked").val()),
    };
  }
  $.ajax({
    url: urlsent,
    type: methodsent,
    data: dataf,
    contentType: "application/json",
    data: JSON.stringify(dataf),
  })
    .done(function (data) {
      console.log(data);
      alert("Thao tác thành công");
      window.location = "index.html";
    })
    .fail(function () {
      alert("Thao tác thất bại");
      console.log(dataf);
      console.log(id);
    });
}
function xacnhansuanv() {
  SentData(`https://localhost:5001/api/Baihoc`, "Put", realid);
}
