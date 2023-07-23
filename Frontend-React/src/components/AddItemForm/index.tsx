import React, { useState, FormEvent } from 'react'
import axios, {AxiosError} from 'axios'
import { TodoItemType } from '../../models';

interface AddItemFormProps {
    handleAdd: (item: TodoItemType) => Promise<void>
}
const AddItemForm: React.FC<AddItemFormProps> = ({ handleAdd }) => {
    const [description, setDescription] = useState('')
    const [descriptionError, setDescriptionError] = useState('');

    const handleFormSubmit = async (event: FormEvent) => {
        event.preventDefault();

        setDescriptionError('');
        if (description.trim() === '') {
            setDescriptionError('Description field cannot be empty.');
            return;
        }

        const dataToSend = {
            description: description,
        };

        try {
            if (process.env.REACT_APP_API_URL) {
                const response = await axios.post(process.env.REACT_APP_API_URL, dataToSend);
                setDescription('');
                handleAdd(response.data)
            } else {
                console.error('can not find API url')
            }
        } catch (error:any ) {
            if (error instanceof AxiosError && error.response) {
                setDescriptionError(error.response.data);
                console.log('Error status:', error.response.status);
                console.log('Error data:', error.response.data);
            }else {
                console.error('An error occurred:', error.message);
            }
        }
    }

    const handelClear = () => {
        setDescription('');
        setDescriptionError('');
    }

    return (<>
        <h1>Add Item</h1>
        <div className='row' style={{ marginBottom: '2em' }}>
            <div className='col-2 '>
                <label >Description</label>
            </div>
            <div className='col-6' style={{ textAlign: 'left' }}>
                <form onSubmit={handleFormSubmit}>
                    <input
                        type='text'
                        id='todoItemDescription'
                        placeholder='Enter description...'
                        value={description}
                        onChange={(event) => setDescription(event.target.value)}
                        style={{ width: '100%', marginBottom: '1em' }} />
                    {descriptionError &&
                        <div className="alert alert-danger" role="alert" data-testid="errorMessage">
                            {descriptionError}
                        </div>}
                    <button
                        type="submit"
                        className="btn btn-primary"
                        style={{ marginRight: '10px' }}>
                        Add Item
                    </button>
                    <button
                        type="button"
                        className="btn btn-secondary"
                        onClick={handelClear}
                        data-testid="clear-button">
                        Clear
                    </button>
                </form>
            </div>
        </div>
    </>)
}

export default AddItemForm;