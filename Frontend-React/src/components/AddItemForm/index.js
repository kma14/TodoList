
import { Image, Alert, Button, Container, Row, Col, Form, Table, Stack } from 'react-bootstrap'

const AddItemForm = ({ handleAdd, handleClear, description, setDescription }) => {
    
    const handleDescriptionChange = (event)=>{
        setDescription(event.target.value);
    }

    return (<>
        <h1>Add Item</h1>
        <div class='row' style={{marginBottom:'2em'}}>
            <div class='col-2 '>
                <label for='todoItemDescription'>Description</label>
            </div>
            <div class='col-6' style={{ textAlign: 'left' }}>
                <form>
                    <input
                        type='text'
                        id='todoItemDescription'
                        placeholder='Enter description...'
                        value={description}
                        onChange={handleDescriptionChange}
                        style={{ width: '100%', marginBottom: '1em'}} />

                    <button
                        type="button"
                        class="btn btn-primary"
                        onClick={() => handleAdd()}>
                        Add Item
                    </button>
                    <button
                        type="button"
                        class="btn btn-secondary"
                        onClick={() => handleClear()}>
                        Clear
                    </button>
                </form>
            </div>
        </div>
    </>)
}

export default AddItemForm;