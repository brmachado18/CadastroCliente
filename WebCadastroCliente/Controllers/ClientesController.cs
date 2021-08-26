using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCadastroCliente.Contexto;
using WebCadastroCliente.Models;

namespace WebCadastroCliente.Controllers
{
    public class ClientesController : Controller
    {
        private readonly CadastroDbContextcs _context;

        public ClientesController(CadastroDbContextcs context)
        {
            _context = context;
        }

        /*
         * APOS CRIAR AS CLASSES DE MODELOS UTILIZEI O PROPRIO RECURSO DO VISUAL STUDIO
         * PARA CRIAR GERAR O CONTROLLER COM CRUD COMPLETO.
         * REALIZEI APENAS ALGUMAS ALTERAÇÕES PONTUAIS PARA TRATAMENTOS DE ERROS E CARREGAMENTO DO OBJETO COMPLETO. 
         * 
         * PARA O ACESSO AO DADOS UTILIZO O CLASSE DE CONTEXTO DO EF CORE COM LINQ
        */

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Ocorreu um erro ao tentar processar a sua solicitação!";
                    return RedirectToAction(nameof(Index));
                }

                var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ID == id);
  
                if (cliente == null)
                {
                    TempData["Error"] = "Cliente não localizado!";
                    return RedirectToAction(nameof(Index));
                }

                _context.RedesSociais.Where(f => f.ClienteID == id).Load();
                _context.Endereco.Where(e => e.ClienteID == id).Load();
                _context.Telefones.Where(t => t.ClienteID == id).Load();

                return View(cliente);

            }
            catch (Exception e)
            {
                TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewBag.Estados = Utils.GetSelectListEstados();
            return View(new Cliente());
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();

                    TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e )
                {
                    TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                    ViewBag.Estados = Utils.GetSelectListEstados();
                    return View(cliente);
                }               
            }
            ViewBag.Estados = Utils.GetSelectListEstados();
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Ocorreu um erro ao tentar processar a sua solicitação!";
                    return RedirectToAction(nameof(Index));
                }

                var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ID == id);

                if (cliente == null)
                {
                    TempData["Error"] = "Cliente não localizado!";
                    return RedirectToAction(nameof(Index));
                }

                _context.RedesSociais.Where(f => f.ClienteID == id).Load();
                _context.Endereco.Where(e => e.ClienteID == id).Load();
                _context.Telefones.Where(t => t.ClienteID == id).Load();
                
                ViewBag.Estados = Utils.GetSelectListEstados();
                return View(cliente);

            }
            catch (Exception e)
            {
                TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Cliente cliente)
        {

            if (id != cliente.ID)
            {
                TempData["Error"] = "Cliente não localizado!";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();

                    TempData["Sucesso"] = "Cliente editado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!ClienteExists(cliente.ID))
                    {
                        TempData["Error"] = "Cliente não localizado!";    
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                        ViewBag.Estados = Utils.GetSelectListEstados();
                        return View(cliente);
                    }
                }
              
            }
            ViewBag.Estados = Utils.GetSelectListEstados();
            return View(cliente);
         
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Ocorreu um erro ao tentar processar a sua solicitação!";
                    return RedirectToAction(nameof(Index));
                }

                var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ID == id);

                if (cliente == null)
                {
                    TempData["Error"] = "Cliente não localizado!";
                    return RedirectToAction(nameof(Index));
                }

                _context.RedesSociais.Where(f => f.ClienteID == id).Load();
                _context.Endereco.Where(e => e.ClienteID == id).Load();
                _context.Telefones.Where(t => t.ClienteID == id).Load();

                return View(cliente);

            }
            catch (Exception e)
            {
                TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                TempData["Sucesso"] = "Cliente excluido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = $"Ocorreu o seguinte error ao tentar processar sua solicitação: {e.Message}";
                return RedirectToAction(nameof(Index));
            }
            
        }

        private bool ClienteExists(long id)
        {
            return _context.Clientes.Any(e => e.ID == id);
        }
        public ActionResult ValidarCliente(string cpf)
        {
            //METODO PARA VALIDAR O CPF REMOTAMENTE NA TELA DE CADASTRO DE CLIENTE.
            //RELACIONADO A ANNOTATION [REMOTE] NO Clietnte.cs MODEL.
            return Json(!_context.Clientes.Any(e => e.CPF == cpf));
        }
    }
}
