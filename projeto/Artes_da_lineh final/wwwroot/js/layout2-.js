
var number1 = 0
function viraSeta(categoria,opcoes,number){
    $(categoria).on("click",function(){  
        if(number%2==0){
            $(this).attr("class","ativado setaBaixo")
            $(opcoes).css({display:"block"})
            number++
        }else{
            $(this).attr("class","setaBaixo")
            $(opcoes).css({display:"none"})
            number++
        }
    })
}
function trocaImagem(li,opcao,src,src2){
    $(li).on("mouseover",function(){
        $(opcao).attr("src",src)
    })
    $(li).on("mouseout",function(){
        $(opcao).attr("src",src2)
    })
}
function showMenu(){
    $("#menu").on("click",function(){
        if(number1%2==0){
            $("section").attr("class","show")
            number1++
        }else{
            $("section").removeAttr("class")
            number1++
        }
    })
}
function loadPage(option,path){
    $(option).on("click",function() {
        $.get(path)
            .done(function(data){
                $("main").html(data)
            })
            .fail(function(){
                alert("Falha na requisição")
            })
    })
}


viraSeta("#desenho",".desenhos",0)
viraSeta("#usuario",".usuarios",0)
viraSeta("#produto",".produtos",0)
viraSeta("#encomenda",".listagem",0)
viraSeta("#site",".site",0)
trocaImagem(".insert",".inserir","/imagens/plusc.png","/imagens/plusb.png")
trocaImagem(".edit",".editar","/imagens/pencilc.png","/imagens/pencilb.png")
trocaImagem(".delete",".excluir","/imagens/binc.png","/imagens/binb.png")
trocaImagem(".list",".lista","/imagens/documentoc.png","/imagens/documento.png")
showMenu()

loadPage("#Dins","/Desenho/Inserir")
loadPage("#Dedit","/Desenho/Modificar")
loadPage("#Ddele","/Desenho/Excluir")

loadPage("#Pins","/Produtos/Inserir")
loadPage("#Pedit","/Produtos/Modificar")
loadPage("#Pdele","/Produtos/Excluir")

loadPage("#Uedit","/Usuario/Modificar")
loadPage("#Udele","/Usuario/Excluir")

loadPage("#Llist","/Pedido/Visualizar")
loadPage("#Ledit","/Pedido/Modificar")
loadPage("#Ldele","/Pedido/Excluir")
loadPage("#Lulist","/Pedido/Uvisualizar")