using FirstApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers;

[ApiController]
[Route("clients")]
public class ClientController : ControllerBase
{
    private static List<Client> _clients = new();
    private static int _nextId = 1;

    [HttpPost]
    public ActionResult Create(ClientRequest request)
    {
        var client = request.CreateClient(_nextId++);
        _clients.Add(client);

        return StatusCode(201, client);
    }

    [HttpGet]
    public ActionResult ListClients()
    {
        return StatusCode(200, _clients);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, ClientRequest request)
    {
        var client = _clients.FirstOrDefault(client => client.Id == id);
        if (client == null) return NotFound("Client não encontrado");

        var updated = request.UpdateClient(client);

        return Ok(client);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var deleted = _clients.RemoveAll(client => client.Id == id);

        if (deleted == 0) return NotFound("Cliente não encontrado");

        return NoContent();
    }
}
