function insert(num){
    var numero = document.getElementById('resultado').innerHTML;
    document.getElementById('resultado').innerHTML = numero + num;
} /*função para enfileirar os numeros através de uma variável temporária num*/

function clean(){
    document.getElementById('resultado').innerHTML = "";
} /*função para apagar todos os numeros inseridos, adicionando vazio no lugar*/

function back(){
    var resultado = document.getElementById('resultado').innerHTML;
    document.getElementById('resultado').innerHTML = resultado.substring(0,resultado.length -1);
} /*função para apagar um numero inserido*/

function calcular(){
    var resultado = document.getElementById('resultado').innerHTML;
    if(resultado){
        document.getElementById('resultado').innerHTML = eval(resultado);
    }
    else{
        document.getElementById('resultado').innerHTML = "Nada...";
    } /*função para caso haja algum input, realizar o cálculo. Caso contrário, não faz nada*/
}