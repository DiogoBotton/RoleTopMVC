function ValidaForm() {
   var senha =  document.getElementById('senha');
   var confirmSenha =  document.getElementById('confirm-senha');

    if(senha.value != confirmSenha.value){
        alert('Confirmação de senha inválida');
        confirmSenha.focus();
    }

}
