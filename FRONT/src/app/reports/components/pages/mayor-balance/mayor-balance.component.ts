import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {DowloadpdfService} from '../../../../services/dowloadpdf.service';
import { RestrictionsService } from 'src/app/services/restrictions.service';
import { FormControl, FormGroup, Validators , } from '@angular/forms';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import { headerRestrictionTable } from 'src/app/models/headerTableRestrictions.model';
import { EntityValidateService } from 'src/app/reports/transversal/entity-validate.service';


@Component({
  selector: 'app-mayor-balance',
  templateUrl: './mayor-balance.component.html',
  styleUrls: ['./mayor-balance.component.scss']
})
export class MayorBalanceComponent {

  @ViewChild("fileDropRef", { static: false }) fileDropEl!: ElementRef ;
  files: any[] = [];
  displayedColumns: string[] = ['cuenta', 'naturaleza', 'tercero', 'valorAjustePeso','update','delete'];
  tableData:any[]=[];
  fileName = '';
  documentStringB64='';
  descargaOk: boolean=false;
  modalSwitch:boolean=false;
  buttonRegisterState="Guardar";
  idRegister:number=0;
  restriction: headerRestrictionTable |null =null;

  formExceptions= new FormGroup({
    id:new FormControl(0),
    cuenta: new FormControl('',Validators.required),
    naturaleza: new FormControl(''),
    tercero:new FormControl(''),
    valorAjustePeso: new FormControl(''),
    checkAjustePeso: new FormControl(),
    checkTercero:new FormControl(),
  });

  constructor(private http: HttpClient, private _downloadpdf: DowloadpdfService, private _getRestrictions: RestrictionsService, private _validateService:EntityValidateService)
  {
    this.clearModel();
    
  }

  onFileSelected(event:any)
  {
    debugger;
    const file: File= event.target.files[0];
    this.sendFile(file);
    
  }

  sendFile(file:File){
    if(file){
      this.fileName=file.name;
      const formData=new FormData();
      formData.append("FileUploadModel",file);
      const upload$=this.http.post("https://localhost:44309/api/Mayor",formData);
      //https://localhost:44309/api/Mayor
      upload$.subscribe();
    }
  }

  onFileDropped($event:any) {
    this.prepareFilesList($event);
  }

  prepareFilesList(files: Array<any>) {
  //prepareFilesList(files: any) {
    for (const item of files) {
      item.progress = 0;
      this.files.push(item);
    }
    this.fileDropEl.nativeElement.value = "";
    this.uploadFilesSimulator(0);
  }

  deleteFile(index: number) {
    if (this.files[index].progress < 100) {
      console.log("Upload in progress.");
      return;
    }
    this.files.splice(index, 1);
  }

  uploadFilesSimulator(index: number) {
    setTimeout(() => {
      if (index === this.files.length) {
        this.sendFile(this.files[0])
        this.descargaOk=true
        return;
      } else {
        const progressInterval = setInterval(() => {
          if (this.files[index].progress === 100) {
            clearInterval(progressInterval);
            this.uploadFilesSimulator(index + 1);
          } else {
            this.files[index].progress += 5;
          }
        }, 200);
      }
    }, 1000);
  }

  formatBytes(bytes:any, decimals = 2) {
    if (bytes === 0) {
      return "0 Bytes";
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals;
    const sizes = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + " " + sizes[i];
  }
  
  async ondownloadpdf()
  {
    
    this._downloadpdf.getPdf().subscribe(result=>{
      this.documentStringB64 = result.data
      this.getPdf();  
    })
    
  }

  getPdf(){
    debugger;
    var blob = this.b64toBlob(this.documentStringB64, "application/pdf");
    let a = document.createElement("a");
    document.body.appendChild(a);
    var url = window.URL.createObjectURL(blob);
    a.href = url;
    a.download = String("Informe Mayor y Balance");
    a.click();
    window.URL.revokeObjectURL(url);
    a.remove();
  }

  public b64toBlob(b64Data:any, contentType:any){
    contentType=contentType || '';
    let sliceSize=512;
    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
  }

  openModal(){
    this.modalSwitch=true;
  }
  clearModel()
  {
    this._getRestrictions.formData={
      id:0,
      cuenta:'',
      naturaleza:'',
      tercero:'',
      valorAjustePeso:0,
      checkAjustePeso:0,
      checkTercero:0,
    }
  }
  saverestriction()
  {
    debugger;
    this._getRestrictions.formData.id=Number(this.formExceptions.controls.id.value);
    this._getRestrictions.formData.cuenta=this.formExceptions.controls.cuenta.value!;
    this._getRestrictions.formData.naturaleza=this.formExceptions.controls.naturaleza.value!;
    this._getRestrictions.formData.tercero=this.formExceptions.controls.tercero.value!;
    this._getRestrictions.formData.valorAjustePeso= Number(this.formExceptions.controls.valorAjustePeso.value!);
    this._getRestrictions.formData.checkAjustePeso= Number(this.formExceptions.controls.checkAjustePeso.value!);
    this._getRestrictions.formData.checkTercero= Number(this.formExceptions.controls.checkTercero.value!);

    switch(this.buttonRegisterState)
    {
      case "Guardar": this._getRestrictions.addRestrictions().subscribe(result=>{
                        if(result.exito===1)
                        {
                          debugger;
                          Swal.fire('Restricciones','La restriccion fue guardada correctamente','success');
                        }
                     });
      break;
      case "Actualizar": if(this.idRegister!=0)
                        {
                          debugger;
                          this._validateService.validate(this.tableData,this._getRestrictions.formData);
                        }

        break;
      case "Borrar":
        break;
    }
  }
  onUpdateRegisterEvent(event:headerRestrictionTable)
  {
    debugger;
    this.idRegister=Number(event.id);
    this.formExceptions.controls.id.setValue(Number(event.id))
    this.formExceptions.controls.cuenta.setValue(event.cuenta);
    this.formExceptions.controls.naturaleza.setValue(event.naturaleza);
    this.formExceptions.controls.tercero.setValue(event.tercero);
    this.formExceptions.controls.valorAjustePeso.setValue(String(event.valorAjustePeso));
    this.formExceptions.controls.checkAjustePeso.setValue(event.checkAjustePeso)
    this.formExceptions.controls.checkTercero.setValue(event.checkTercero)
    this.buttonRegisterState="Actualizar"
  }
}
