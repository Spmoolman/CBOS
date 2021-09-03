import { Component, OnInit } from '@angular/core';
import { ContactModel } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { AlertService } from '../_alert';
import { ModalService } from '../_modal';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  public allContacts: ContactModel[];
  public contactToBe: ContactModel;
  public isUpdate: boolean;

  private options = {
    autoClose: true,
    keepAfterRouteChange: false
  };

  constructor(
    private contactService: ContactService,
    protected alertService: AlertService,
    private modalService: ModalService) {
  }

  public async ngOnInit(): Promise<void> {
    this.contactToBe = new ContactModel();
    this.loadTableData();
  }

  // Loads the table data
  private async loadTableData(): Promise<void> {
    this.allContacts = await this.contactService.getContacts().toPromise();
  }

  // Not being used. Was intended to get the data for the modal. Found a better way to send all the data to the modal
  public async getContact(id): Promise<void> {
    await this.contactService.getContact(id).toPromise();
  }

  // Deletes a contact
  public async deleteContact(id): Promise<void> {
    const isDeleted = await this.contactService.deleteContact(id).toPromise();

    if (isDeleted) {
      this.alertService.success('Contact was deleted', this.options);
    } else {
      this.alertService.error('Could not delete record', this.options);
    }

    this.loadTableData();
  }

  // When saving on the modal depending if it is an update or a new contact, it will save the new data
  public async save(id: string): Promise<void> {
    this.modalService.close(id);
    let hasSaved = false;

    if (this.isUpdate) {
      hasSaved = await this.contactService.updateContact(this.contactToBe).toPromise();
    } else {
      hasSaved = await this.contactService.saveContact(this.contactToBe).toPromise();
    }

    if (hasSaved) {
      this.loadTableData();
      this.alertService.success('Data was saved', this.options);
    } else {
      this.alertService.error('Data could not be saved', this.options);
    }

    this.contactToBe = new ContactModel();
  }

  // Opens the modal and set if it is an update or new contact
  public openModal(id: string, isUpdate: boolean, contact: ContactModel) {
    this.modalService.open(id);
    this.isUpdate = isUpdate;

    if (isUpdate) {
      this.contactToBe = contact;
    }
  }

  // Closes the modal
  public closeModal(id: string) {
      this.modalService.close(id);
  }
}
