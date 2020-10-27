$("#inserir").on("click",function() {
    alert(`${$("#nome").val()} inserido com sucesso`)
    
})
function Mudaimagem(atributo){
    $(atributo).change(() =>{
        var imagem = $(atributo).val().split('\\').pop()
        $("#imag").attr('src', `../imagens/${imagem}`)
        $(".invisible").attr('class',"visible")
    })
}
var a = 2
var b = 255
var c = 0
var d = 255
$("#add").on("click",()=>{
    if(a<=5){
        b-=50
        $(`#label${a}`).removeClass("invisibleImg")
        $(`#imagem${a}`).removeClass("invisibleImg")
        $(`#imagem${a}`).css({background:`rgb(${b},${c},${d})` })
        a++      
        c+=50
        d-=50
    }if(a===6){
        $("#add").css({display:"none"})
    }
})

Mudaimagem("#img")
Mudaimagem(".imagem")
Mudaimagem("#imagem2")
Mudaimagem("#imagem3")
Mudaimagem("#imagem4")
Mudaimagem("#imagem5")
