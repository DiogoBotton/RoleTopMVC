namespace RoleTOP_MVC.Repositories {
    public class BaseRepository {
        protected string ExtrairValorDoCampo (string nomeCampo, string linha) {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf (chave);
            var indiceTerminal = linha.IndexOf (";", indiceChave); //IndexOf sempre retorna o indice do ultimo caracter da string.

            var valor = "";
            //IndexOf retorna -1 caso não encontre o valor de string.
            if (indiceTerminal != -1) { //Caso for diferente de -1, primeiro parametro startIndex, segundo EndIndex.
                valor = linha.Substring (indiceChave, indiceTerminal - indiceChave);
            } else {
                valor = linha.Substring (indiceChave); //caso for igual á -1, unico parametro startIndex até o final da string.
            }
            //System.Console.WriteLine ($"Campo {nomeCampo} e valor {valor}");
            return valor.Replace (nomeCampo + "=", "");
        }
    }
}