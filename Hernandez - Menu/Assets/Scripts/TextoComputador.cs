using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextoComputador : MonoBehaviour
{
    [SerializeField] private GameObject painel;
    [SerializeField] private GameObject resposta;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject areaDeTrabalho;
    [SerializeField] private GameObject telaDeBloqueio;
    [SerializeField] private GameObject notepad;
    [SerializeField] private TMP_InputField inputSenBloqueio;
    private string senhaComputador = "linguiça";
    private string senhaArquivo = "A Noite Estrelada";
    private bool ativo = false;
    private bool ehSenha = true;
    private bool acessado = false;

    void Awake()
    {
        if(acessado){
            VerificaSenhaUser(senhaComputador);
        }
    }

    public void AbreBloco(){
        if(!ativo){
            this.painel.SetActive(true);
            this.ativo = true;
        }
    }

    public void FechaBloco(){
        if(ativo){
            this.painel.SetActive(false);
            this.ativo = false;
        }
    }

    public void FechaNotes(){
        this.notepad.SetActive(false);
    }
    public void AbreNotes(){
        this.notepad.SetActive(true);
    }

    public void VerificaSenha(string senha){
        if(senha == senhaArquivo){
            this.resposta.SetActive(true);
            this.block.SetActive(false);
            Actions.OnStoryAdvanced(7);
        }
    }

    public void VerificaSenhaUser(string senha){
        if(senha == senhaComputador){
            this.areaDeTrabalho.SetActive(true);
            this.telaDeBloqueio.SetActive(false);
            acessado = true;
            Actions.OnStoryAdvanced(6);
        }
    }

    public void MudaTipoTexto(){
        if(ehSenha){
            this.inputSenBloqueio.contentType = TMP_InputField.ContentType.Standard;
            ehSenha = !ehSenha;
        } 
        else {
            this.inputSenBloqueio.contentType = TMP_InputField.ContentType.Password;
            ehSenha = !ehSenha;
        }
        inputSenBloqueio.Select();
    }
}
